using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuntTheWumpus
{
    /// <summary>
    /// The GameControl object performs all of the game-related actions.  
    /// It is the "C" in the Model/View/Controler (MVC) stack.
    /// </summary>
    public class GameControl
    {
        public enum boardType { NewGame, PlayAgain};

        // We share the Random Number Generator (RNG) with the rest of the application.
        // We do this to ensure the integrety of the random results returned.  If we used
        // more than one RNG, there could be duplications in the series of randoms produced.
        public Random rng = new Random();

        // References to other game objects we have created.  These are private members
        // of the class.
        UserInterface ui;   // The UserInterface object that created the GameControl object.
        Map map;            // The Map object for the current game.
        Player player;      // The Player object for the current player.
        Cave cave;          // The current Cave object the game is using.
                            // Wumpus wumpus;

        // The non-object members of the class.  These are also private members.
        bool gameInProgress = false;    // When we are starting out, there is no game in progress.
        int turnCounter;

        // Public members
        // TODO: Determine how best to make these non-public.
        public int caveSelection;   // The player's selection of what cave to play.

        // CONSTRUCTOR
        /// <summary>
        /// Construct the GameControl object
        /// </summary>
        /// <param name="ui">The UserInterface object that created this GameControl object</param>
        public GameControl(UserInterface ui)
        {
            this.ui = ui;
            player = new HuntTheWumpus.Player(this);
        }

        /// <summary>
        /// The UserInterface object has instructed us to save the player's name
        /// Send this over to the Player object.
        /// </summary>
        /// <param name="playerName">The name to set as the current player</param>
        internal void setPlayerName(string playerName)
        {
            // Use the public interface presented by the Player object.
            player.PlayerName = playerName;
        }

        /// <summary>
        /// Public getter for the turnCounter
        /// </summary>
        public int TurnCounter
        {
            get
            {
                return turnCounter;
            }
        }

        /// <summary>
        /// Return the current status of the game engine.
        /// </summary>
        /// <returns>A 'true' value if a game is in progress, and 'false' if otherwise.</returns>
        public bool isGameInProgress() { return gameInProgress; }

        /// <summary>
        /// (Overloaded)
        /// Start a new game.  In this case, the player's name has been provided, so
        /// set that.  Then call the other version of this call to actually start the game.
        /// </summary>
        /// <param name="board">The desired board to play</param>
        /// <param name="playerName">The name of the current player</param>
        public void startGame(boardType board, string playerName)
        {
            player.PlayerName = playerName;
            startGame(board);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        public void startGame(boardType board)
        {
            // If a new game board has been requested...
            if (board == boardType.NewGame)
            {
                // Starting a new game so build the new cave and map objects
                // TODO: right now this builds a random cave.  We need to be able
                // to specify which board to play.
                cave = new Cave(this);
                map = new HuntTheWumpus.Map(this);
                map.randomize();                    // Randomize the game board...
            } else
            {
                // Replaying the same game, so no need to recreate the cave, however...
                // ...put everything back where it started before...
                map.playAgain();
            }
            // We get here whether we are starting with a new random cave/map, or 
            // replaying the previous map.  Either way, the core objects are ready
            // to begin.

            // Initialize the counters to the starting values...
            player.ArrowCount = 3;
            player.CoinCount = 0;
            turnCounter = 0;
            ui.setErrorMessage("");                 // Clear the error message field
            gameInProgress = true;                  // ...and the game is afoot.
        }

        public void endGame()
        {
            map.movePlayerToLobby();
            gameInProgress = false;
            // TODO: Show the current score and high scores
        }

        // This is the basic "Move" turn executor
        public bool movePlayer(Cell.Direction dir)
        {
            bool result = map.movePlayer(dir);
            if (result)
            {
                turnCounter++;
                if (player.CoinCount++ > 100)
                {
                    // There are a maximum of 100 coins
                    player.CoinCount = 100;
                }
                int batSnatched;
                int movedByBats = 0;    // We have not been moved by bats this turn.
                // Wrap the hazzard checks because we need to recheck for hazzards as long as
                // the bats are moving us.
                do
                {
                    batSnatched = 0;    // So far in this mini-turn, we have not been snatched by bats.

                    // Check to see if we have run into a hazzard
                
                    if (map.checkForPit())
                    {
                        if (movedByBats == 0)
                        {
                            // We've fallen into a pit
                            playerLoses("YYYIIIIEEEE...Fell into a pit!");
                        }
                        else
                        {
                            // Those pesky bats...
                            playerLoses("Those pesky bats dropped you in a pit!");
                        }
                    }

                    if (map.checkForWumpus())
                    {
                        // We bumped the Wumpus...lets see if he's hungry
                        // There is a 20% (1 in 5) chance that the player will lose
                        if (rng.Next(1, 6) == 1)
                        {
                            // Player rolled a 1...
                            playerLoses("You ran into a hungry Wumpus!");
                        }
                        else
                        {
                            // Wumpus was not hungry, but startled he runs off...
                            ui.setErrorMessage("Ooops...bumped the Wumpus.");
                            map.moveWumpus();
                            // It is possible for the Wumpus to move back into our room
                            if (map.checkForWumpus())
                            {
                                // The Wumpus moved but came back
                                playerLoses("The Wumpus ran off, but came back to eat you!");
                            }
                        }
                    }

                    if (map.checkForBats())
                    {
                        // We've been picked up by bats
                        if (movedByBats == 0)
                        {
                            ui.setErrorMessage("Zap--SuperBat snatch! Elsewhereville for you!");
                        } else
                        {
                            ui.setErrorMessage("The bats are playing catch with you");
                        }
                        map.movePlayerToRandomRoom();
                        batSnatched = 1;    // We need to repeat the mini-turn to see 
                                            // if the bats dropped us on another hazzard.
                        movedByBats = 1;    // Some of the messages are different if we've been snatched.
                    }
                } while (batSnatched == 1);
            }
            return result;
        }

        public enum shootArrowResults { NOPATH=-1, MISS, HIT }

        public shootArrowResults shootArrow(Cell.Direction dir)
        {
            // First check for path to the room
            if (cave.getRoom(getPlayerRoom()).nearbyRooms[(int)dir] == -1)
            {
                // No path that direction
                return shootArrowResults.NOPATH;
            }
            turnCounter++;
            shootArrowResults result = map.shootArrow(dir);
            player.arrowUsed(); 
            switch (result) {
                case shootArrowResults.MISS:
                    // Possible game play result: Wumpus wakes up, or increases his anger level.
                    break;
                case shootArrowResults.HIT:
                    playerWins();
                    break;
            }
            if (result == shootArrowResults.MISS && player.ArrowCount == 0)
            {
                // Ran out of arrows
                playerLoses("You ran out of arrows");
            }
            return result;
        }

        public int getPlayerRoom()
        {
            return map.getPlayerRoom();
        }

        public Cave getCurrentCave()
        {
            return cave;
        }

        public byte hazzardNearby()
        {
            return map.hazardNearby();
        }

        void playerWins()
        {
            // Compute score
            int score = 100 - turnCounter + player.CoinCount + (player.ArrowCount * 10);
            ui.updateUI();      // Update the turn counters
            PlayerWinsDialog dlg = new PlayerWinsDialog(score);
            DialogResult result = dlg.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    startGame(boardType.NewGame);
                    break;
                default:
                    gameOver();
                    break;
            }
        }

        void playerLoses(string reason)
        {
            PlayerLosesDialog dlg = new PlayerLosesDialog(reason);
            DialogResult result = dlg.ShowDialog();
            switch (result)
            {
                case DialogResult.Retry:
                    startGame(boardType.PlayAgain);
                    break;
                case DialogResult.OK:
                    startGame(boardType.NewGame);
                    break;
                default:
                    gameOver();         // User doesn't want to start a new game just yet.
                    break;
            }
        }

        void gameOver()
        {
            map.movePlayerToLobby();
            gameInProgress = false;
        }

        public string getPlayerName()
        {
            if (player != null)
            {
                return player.PlayerName;
            }
            return "";
        }

        public int getPlayerArrows()
        {
            return player.ArrowCount;
        }

        public int getPlayerCoins()
        {
            return player.CoinCount;
        }
    }
}
