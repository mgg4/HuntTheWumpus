using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HuntTheWumpus
{
    public class Cave
    {
        //private static int nbrStaticCaves = 0;
        GameControl gc;
        bool[] seen = new bool[30];

        // This is the holder for the array of Cell objects we will create
        Cell[] cell;

        /// <summary>
        /// Create a valid random Cave object.  
        /// </summary>
        /// <param name="gc">The GameControl object owning this Cave object</param>
        public Cave (GameControl gc)
        {
            bool valid;
            int i;

            this.gc = gc;               // Record the GameControl owner of the cave
            cell = new Cell[30];        // Allocate space for the 30-room grid.

            // Repeat the following until we have a valid cave.
            do
            {
                // Build the basic Cave structure.  This creates the grid of the 30 rooms.
                for (i = 0; i < 30; i++)
                {
                    // Populate the array element with a newly created Cell object.
                    // Must offset the room number as the array is zero based, and
                    // the room numbers start at 1.  (cell[0] == Room 1)
                    cell[i] = new HuntTheWumpus.Cell(i + 1);
                }

                valid = true;  // Assume a valid cave

                // TODO: Clean this up so it is not two separate passes, but rather a loop
                // that calls the closeRandomTunnel code from only one place.

                // First attempt at generating a random cave
                // First pass, close one tunnel from each room.
                bool roomClosedThisPass;
                do
                {
                    roomClosedThisPass = false;
                    for (i = 0; i < 30; i++)
                    {
                        if (cell[i].nbrOpenTunnels() > 3)
                        {
                            closeRandomTunnel(i);
                            roomClosedThisPass = true;

                        }
                    }
                } while (roomClosedThisPass);

                // validateCave() will ensure there are no cutoff rooms
                // Rooms can be cutoff by having no tunnels open, and also by
                // being unreachable from other rooms.  That is, a individual
                // room may have tunnels connected, but if that group of rooms
                // is not reachable from other parts of the cave, the cave is
                // not valid.
                valid = validateCave(this);
            } while (valid == false);
            // Valid cave object exists now.
        }

        /// <summary>
        /// Load the specified static cave from the configuration files.
        /// </summary>
        /// <param name="gc">The GameControl object owning this cave</param>
        /// <param name="caveNumber">The number of the cave to load</param>
        public Cave (GameControl gc, int caveNumber)
        {
            // TODO: Create the code to load and validate a cave from the
            // configuration files.
        }

        // Validate the current cave.
        private bool validateCave()
        {
            return validateCave(this);
        }
        
        // Validate a specific Cave object
        private bool validateCave (Cave cave)
        {
            int i;

            // Validate the cave.
            // A valid cave must meet the following conditions:
            //  1. Every room must have between 1 and 3 connections to other rooms.
            //  2. All rooms must be reachable from every other room.

            // Hypothesis: If every room can be reached from room 1, then all
            // rooms can be reached from every other room.

            // Check each room in the cave to ensure the proper number of tunnels is open.
            for (i = 0; i < 30; i++)
            {
                int n = cave.cell[i].nbrOpenTunnels();
                // If there are less than 1 or more than 3 tunnels open...
                if (n < 1 || n > 3)
                {
                    // ...the cave is not valid
                    return false;
                }
            }
            // At this point, we have a cave that has passed the first condition.  Now walk the 
            // cave to ensure all rooms can be reached.
            // ...but first reset the array we use to record the rooms we've seen.
            for (i = 0; i < 30; i++) cave.seen[i] = false;

            // Start our walk at room 1.  WalkRoom() will recursively walk the rooms that can
            // be reached from this starting point.  walkRoom() will set the seen[] array as
            // rooms are visited.
            walkRoom(cave, 1);

            // walkRoom() returns when all tunnels that can be reached have been walked.
            // Now scan the array to ensure all rooms have been reached.
            for (i = 0; i < 30; i++)
            {
                if (!cave.seen[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get the Cell object representing the specified room.
        /// </summary>
        /// <param name="roomNbr">The desired room number.</param>
        /// <returns>The Cell ojbect for the requested room. </returns>
        public Cell getRoom(int roomNbr)
        {
            return cell[roomNbr - 1]; // Adjust for zero based array
        }


        /// <summary>
        /// Wrapper to walk the current cave.  
        /// Will only be called to start the walk.  Recursive calls will contain the cave
        /// parameter.
        /// </summary>
        /// <param name="room">Integer number of the room to walk from</param>
        private void walkRoom(int room)
        {
            walkRoom(this, room);
        }

        /// <summary>
        /// Walk the specified cave from the specified room
        /// </summary>
        /// <param name="cave">The Cave object to walk</param>
        /// <param name="room">The Integer number of the room to walk from</param>
        /// <remarks>walkRoom() has the side effect of modifying the seen[] array in the Cave object.</remarks>
        private void walkRoom(Cave cave, int room)
        {
            int i;
            room--;     // Adjust the index
            if (cave.seen[room]) return;     // No need to continue if we've seen this room.
            cave.seen[room] = true;          // We've now seen this room.
            // For each of the nearby rooms...
            for (i=0; i<6; i++)
            {
                // Use recursion to completely walk all rooms we can reach.
                int destroom = cave.cell[room].nearbyRooms[i];  //...get the destination room...
                if (destroom > 0) walkRoom(cave, destroom);     //...and walk the tree from that room.
            }
        }



        //private bool closeRandomTunnel(int room)
        private void closeRandomTunnel(int room)
        {
            int dir;
            bool closed = false;

            do
            {
                dir = gc.rng.Next(0, 6);
                if (cell[room].nearbyRooms[dir] > 0)
                {
                    closeCaveTunnel(room + 1, (Cell.Direction)dir);
                    closed = true;
                }
            } while (closed == false);
        }

        private void closeCaveTunnel(int roomNbr, Cell.Direction direction)
        {
            // Get the two cells we need to change.
            Cell srcCell = getRoom(roomNbr);
            Cell dstCell = getRoom(srcCell.roomTo(direction));
            // Now close off the tunnel from the source direction.
            srcCell.closeTunnel(direction);
            // A bit of hand-waving is required to get the reciprical direction.
            // Convert the direction to the integer, then add 3 to get the reciprical.
            // Use modulus math to wrap around to the other half of the array.
            // The reciprical of 1 becomes 4.  The reciprical of 4 becomes 1 (7 % 6 is 1).
            Cell.Direction reciprical = (Cell.Direction)(((int)direction + 3) % 6);
            dstCell.closeTunnel(reciprical);
        }

        // TODO: Implement the loading of static caves.
        //public void LoadCave(int caveNumber)
        //{
        //    File.ReadAllLines();
        //}
    }
}
