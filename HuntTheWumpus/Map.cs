using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
    /// <summary>
    /// The Map object contains the information about the location of the entities and hazzards in the game.
    /// </summary>
    class Map
    {
        GameControl gc;

        int playerRoom;
        int playerStartRoom;
        int wumpusRoom;
        int wumpusStartRoom;
        int[] pitRooms;
        int[] batRooms;

        public Map(GameControl gc)
        {
            this.gc = gc;
            playerRoom = -1;
            pitRooms = new int[2];
            batRooms = new int[2];
        }

        /// <summary>
        /// Place the Player, Wumpus, and hazards in random places in the cave.  However
        /// ensure that there are no overlaps.  While the Wumpus can be in the same room
        /// as a hazard later, the spec calls for Wumpus' starting position to not coincide
        /// with another hazard.  The player may also not start in a room that contains a
        /// hazard.
        /// </summary>
        public void randomize()
        {
            // Randomly place the Wumpus in the cave
            wumpusStartRoom = wumpusRoom = gc.rng.Next(1, 31);

            // Wrap the player randomizer to ensure the Player and Wumpus 
            // are NOT in the same room.
            do
            {
                playerStartRoom = playerRoom = gc.rng.Next(1, 31);
            } while (playerRoom == wumpusRoom);

            // Temporary array to hold random numbers while we validate there are no collisions
            int[] randNbrs = new int[4];

            // flags and iterators for the collision check
            bool valid;
            int i, j;

            // Wrap the randomization of the other hazzards to ensure they do not also
            // share a room with the Player or the Wumpus.
            do
            {
                // Assume the map is valid to start the loop.
                valid = true;
                // Generate 4 room numbers
                for (i = 0; i < 4; i++)
                {
                    // Use the RNG from the GameControl object to generate random room numbers
                    randNbrs[i] = gc.rng.Next(1, 31);
                }

                // Now look for collisions
                for (i = 0; i < 4; i++)
                {
                    // First check for collision with the Player or Wumpus
                    if (randNbrs[i] == playerRoom || randNbrs[i] == wumpusRoom)
                    {
                        valid = false;
                        goto tryAgain;
                    }
                    else
                    {
                        // No collision with entities so check for collisions with other hazards
                        // Start with current value of the outer loop
                        for (j = i; j < 4; j++)
                        {
                            // Skip comparison to self
                            if (j == i) continue;
                            // If these two numbers are equal, we have a collision.  
                            // Set the collision flag and break the loop.
                            if (randNbrs[i] == randNbrs[j])
                            {
                                valid = false;
                                goto tryAgain;
                            }
                        }
                    }
                }
                // We now have random numbers that don't collide with anything.
                // Make two passes, and assign the random rooms to the hazards.
                for (i = 0; i < 2; i++)
                {
                    // First pass will look at nodes 0 (0 * 2) and 1 ((0 * 2) + 1)
                    // Second pass will get nodes 2 (1 * 2) and 3 ((1 * 2) + 1)
                    // Even numbered slots will be the pit rooms, and odd numbered will have bats in them.
                    pitRooms[i] = randNbrs[(i * 2)];
                    batRooms[i] = randNbrs[(i * 2) + 1];
                }

                // Randomization is now complete
                // Now check to see if the wumpus or player is in a cul-de-sac (only
                // one exit, where the exit room is a hazard.

                // TODO: This check should really be checking each destination room from the 
                // rooms where the player and Wumpus are located.  If all rooms from each
                // lead to hazards, then we have a problem.
                Cave cave = gc.getCurrentCave();
                if (cave.getRoom(playerRoom).nbrOpenTunnels() == 1)
                {
                    // A check of > 1 omits the Wumpus as a hazzard during this check
                    if (hazardNearby(playerRoom) > 1)
                    {
                        valid = false;
                        goto tryAgain;
                    }
                }
                if (cave.getRoom(wumpusRoom).nbrOpenTunnels() == 1)
                {
                    // A check of > 1 omits the Wumpus as a hazzard during this check
                    if (hazardNearby(wumpusRoom) > 1)
                    {
                        valid = false;
                        goto tryAgain;
                    }
                }

            tryAgain:
                ;
            } while (!valid);  // Keep trying random places for each until a valid set is found.
        }

        /// <summary>
        /// User has requested to replay the same setup.  The Wumpus and Player may have
        /// moved from their original starting place, so they need to be put back where they
        /// started.  The bats and pits can't move, so no need to reposition those.
        /// </summary>
        public void playAgain()
        {
            playerRoom = playerStartRoom;
            wumpusRoom = wumpusStartRoom;
        }

        /// <summary>
        /// Deposit the player in the specified room.
        /// This will be used at the start of the game to put the player in a random starting room,
        /// as well as after the bats have snatched up the player.
        /// </summary>
        /// <param name="roomNbr"></param>
        public void movePlayerToRoom(int roomNbr)
        {
            playerRoom = roomNbr;
        }

        /// <summary>
        /// Move the player to a random room.  It is possible this random room will contain a hazard.
        /// Used to position player after the SuperBat has grabbed the player.
        /// </summary>
        public void movePlayerToRandomRoom()
        {
            // Pick a random room number and move the player to that room.
            movePlayerToRoom(gc.rng.Next(1, 31));
        }

        /// <summary>
        /// The player needs to be placed in a random safe room.  
        /// </summary>
        public void movePlayerToRandomSafeRoom()
        {
            // Move the player to a random room, but only if it is deemed safe.
            do
            {
                movePlayerToRandomRoom();
            } while (checkForBats() == true || checkForPit() == true || checkForWumpus() == true);
        }

        /// <summary>
        /// The Wumpus has been startled, and is running away.  The Wumpus will move between
        /// 2 and 4 rooms.  Each room is in a random direction.  It is possible for the Wumpus to
        /// end up back in the same room it started (the same room the player is in).
        /// </summary>
        public void moveWumpus()
        {
            // Randomize how many rooms to move
            int nbrRooms = gc.rng.Next(2, 5);  // A number between 2 and 4.

            // Now execute the move loop
            int i;
            for (i=nbrRooms;i>0;i--)
            {
                moveWumpusRandomDirection();
            }
        }

        /// <summary>
        /// The Wumpus is on the move.  Move the Wumpus in a random direction.
        /// </summary>
        private void moveWumpusRandomDirection()
        {
            Cell cell = gc.getCurrentCave().getRoom(wumpusRoom);
            int destRoom;
            do
            {
                destRoom = cell.nearbyRooms[gc.rng.Next(0, 6)];
            } while (destRoom == -1);
            wumpusRoom = destRoom;
        }

        /// <summary>
        /// Move the player in the direction specified, if possible.
        /// </summary>
        /// <param name="dir"></param>
        public bool movePlayer(Cell.Direction dir)
        {
            Cell cell = gc.getCurrentCave().getRoom(playerRoom);
            if (cell.roomTo(dir) < 1)
            {
                // Can't go that direction
                return false;
            }
            playerRoom = cell.roomTo(dir);
            return true;
        }

        /// <summary>
        /// Move the player out of the cave
        /// </summary>
        public void movePlayerToLobby()
        {
            playerRoom = -1;
        }

        /// <summary>
        /// Getter for the playerRoom value
        /// </summary>
        /// <returns>the player's current room</returns>
        public int getPlayerRoom()
        {
            return playerRoom;
        }

        /// <summary>
        /// The GameControl has requested the results of shooting an arrow in the specific direction.
        /// </summary>
        /// <param name="dir">The direction to shoot</param>
        /// <returns>An enum indicating the result (HIT or MISS)</returns>
        public GameControl.shootArrowResults shootArrow(Cell.Direction dir)
        {
            if (gc.getCurrentCave().getRoom(playerRoom).roomTo(dir) == wumpusRoom)
            {
                return GameControl.shootArrowResults.HIT;
            }
            else
            {
                return GameControl.shootArrowResults.MISS;
            }
        }

        /// <summary>
        /// Check to see if there are hazards near the player's current room
        /// </summary>
        /// <returns>A bitmap in a byte (See remarks)</returns>
        /// <remarks>Only the 3 least-significant bits are used. 001 = wumpus, 010 = pit, 100 = bat.  Multiple bits may be set.</remarks>
        public byte hazardNearby()
        {
            return hazardNearby(playerRoom);
        }

        /// <summary>
        /// Check for hazards around the designated room.
        /// </summary>
        /// <param name="roomNbr">The room number to check from</param>
        /// <returns>A bitmap in a byte (See remarks)</returns>
        /// <remarks>Only the 3 least-significant bits are used. 001 = wumpus, 010 = pit, 100 = bat.  Multiple bits may be set.</remarks>
        public byte hazardNearby(int roomNbr)
        {
            byte retVal = 0;        // Clear the bitmap that we will return.
            Cell cell = gc.getCurrentCave().getRoom(roomNbr);   // Get the requested cell
            int i;
            // Check the adjacent rooms
            for (i = 0; i < 6; i++)
            {
                // If the wumpus is nearby, set the 1's bit
                if (cell.nearbyRooms[i] == wumpusRoom) { retVal |= 1; }
                int j;
                // There are two of each of the remaining hazards
                for (j = 0; j < 2; j++)
                {
                    // If a pit is nearby, set the 2's bit
                    if (cell.nearbyRooms[i] == pitRooms[j]) { retVal |= 2; }
                    // if a bat is nearby, set the 4's bit
                    if (cell.nearbyRooms[i] == batRooms[j]) { retVal |= 4; }
                }
            }
            // Return the completed bitmap
            return retVal;
        }

        /// <summary>
        /// Check to see if the player is now in the same room as the Wumpus.
        /// </summary>
        /// <returns>True if the player is in the Wumpus' room</returns>
        public bool checkForWumpus()
        {
            return checkForWumpus(playerRoom);
        }

        /// <summary>
        /// Check to see if the Wumpus is in the designated room
        /// </summary>
        /// <param name="room">Room to check for the Wumpus</param>
        /// <returns>True if the Wumpus is in the requested room</returns>
        public bool checkForWumpus(int room)
        {
            return (room == wumpusRoom);
        }

        /// <summary>
        /// Check to see if the player has moved into a room with a pit.
        /// </summary>
        /// <returns>True if the player is now in a pit room</returns>
        public bool checkForPit()
        {
            return checkForPit(playerRoom);
        }

        /// <summary>
        /// Check to see if the designated room contains a pit
        /// </summary>
        /// <param name="room">Room to check for a pit</param>
        /// <returns>True if a pit is found in the requested room</returns>
        public bool checkForPit(int room)
        {
            int i;
            for (i=0;i<2;i++)
            {
                if (room == pitRooms[i]) { return true; }
            }
            return false;
        }

        /// <summary>
        /// Check to see if the player has moved into a room with a SuperBat.
        /// </summary>
        /// <returns>True if the player is now in a bat room</returns>
        public bool checkForBats()
        {
            return checkForBats(playerRoom);
        }

        /// <summary>
        /// Check to see if the designated room contains a bat.
        /// </summary>
        /// <param name="room">Room to check for a bat</param>
        /// <returns>True if a batis found in the requested room</returns>
        public bool checkForBats(int room)
        {
            int i;
            for (i = 0; i < 2; i++)
            {
                if (room == batRooms[i]) { return true; }
            }
            return false;
        }
    }
}
