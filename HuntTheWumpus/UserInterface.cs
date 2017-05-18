using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuntTheWumpus
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The GameControl object is vital to the operation of the game.
        /// </summary>
        public GameControl gc;

        /// <summary>
        /// Create the generic UserInterface object.  This is the primary window
        /// object for the application.
        /// </summary>
        public UserInterface()
        {
            //Initialize the Visual Studio libraries.  DO NOT REMOVE OR ALTER THIS.
            InitializeComponent();

            // Create the game controller needed.
            gc = new GameControl(this);

            // Since we know the user is here to play, let's go ahead and start a new game.
            startNewGame();

            // At this point we just let the Program object take control to run our form.
            // We will now deal with the events created as the user plays the game.
        }

        //private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        //{

        //}

        /// <summary>
        /// Handle the event created by the user closing the window with the "X" button.
        /// </summary>
        /// <param name="sender">Object sending the event (Not used)</param>
        /// <param name="e">Event arguments (Used to cancel if player wants to continue)</param>
        private void UserInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if game is in progress
            if (gc.isGameInProgress())
            {
                QuitGameDialog quitDialog = new QuitGameDialog(this);
                DialogResult answer = quitDialog.ShowDialog();
                if (answer != DialogResult.Yes)  // User wants to continue, so cancel the FormClosing event
                {
                    e.Cancel = true;
                }
                quitDialog.Dispose();
            }
            // Normal action at this point would be to close the form, so allow the rest of the event handlers to do their work.
        }

        // Menu event handlers
        // "File" menu

        /// <summary>
        /// User has requested to save the current game.
        /// This function is not yet implemented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To be implemented
        }

        /// <summary>
        /// User has requested to load a previously saved game.
        /// This function is not yet implemented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To be implemented
        }

        /// <summary>
        /// User has requested to close Hunt The Wumpus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // game in progress check moved to the form closing event.
            this.Close();
        }

        // "Game" menu

        /// <summary>
        /// User has requested to start a new game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Call the helper function to start a new game.
            startNewGame();
        }

        /// <summary>
        /// User has requested the current game be stopped.  This does not exit the program,
        /// just cancels the current game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gc.endGame();
            updateUI();
        }

        /// <summary>
        /// User has requested to open the Options control panel
        /// This has not yet been implmented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// User wants to see the high scores.
        /// This function has not yet been implemented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showHighScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        // "Help" menu

        /// <summary>
        /// User wants to know how to play Hunt The Wumpus.  Show the Instructions dialog.
        /// This function is not yet implemented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the Game Instructions dialog
        }

        /// <summary>
        /// User is stuck and wants to buy a secret.
        /// This function is not yet implemented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buyAHintToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// User wants details about Hunt The Wumpus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutHuntTheWumpus dlg = new AboutHuntTheWumpus();
            dlg.ShowDialog();
        }

        // Helper functions, mostly related to updating the game board fields.


        /// <summary>
        /// The turn is ended, and the game board needs to be updated to reflect the
        /// current state of the game.  This function should be called at the end of every turn.
        /// </summary>
        internal void updateUI()
        {
            if (gc.isGameInProgress())
            {
                // There is a game in progress so update the board.
                updateRoomFields();
                updatePlayerStats();
                updateMessages();
                setRandomHintMessage();
            } else
            {
                // Game no longer in progress. Clear the game board.
                clearRoomLabels();
                turnField.Text = "";
                coinsField.Text = "";
                arrowsField.Text = "";
                messageBox.Text = "";
                errorField.Text = "";
                hintText.Text = "";
            }
        }

        /// <summary>
        /// Update the rooms on the game play panel.
        /// </summary>
        private void updateRoomFields()
        {
            int i;
            int roomNbr = -1;                   // Player's room
            if (gc.isGameInProgress())
            {
                roomNbr = gc.getPlayerRoom();   // Since a game is running, get the room the player is in.
            }
            if (roomNbr > 30 || roomNbr < 1)    // If the number is not in range, then something is very wrong.
            {
                clearRoomLabels();              // Clear the board.  This is probably an underreaction.
            }
            else // Game in progress and player's room appears to be valid.
            {    
                // Set the display of the player's current room.  This will likely be a hidden
                // field later.
                playerRoomField.Text = roomNbr.ToString();

                // Get the cell representing the player's current room.
                Cell cell = gc.getCurrentCave().getRoom(roomNbr);

                // Iterate through the nearbyRooms to get the status of the tunnels to these
                // rooms.  
                // NOTE: currently we show the room numbers.  The spec is somewhat vague about
                // whether the room numbers are supposed to be known.  The original game did display
                // the current and connected rooms, but the spec provided seems to indicate this
                // information should be hidden.  For now, display the room numbers in the proper
                // positions.
                for (i = 0; i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                            roomNW.Text = cell.nearbyRooms[i].ToString();
                            break;
                        case 1:
                            roomN.Text = cell.nearbyRooms[i].ToString();
                            break;
                        case 2:
                            roomNE.Text = cell.nearbyRooms[i].ToString();
                            break;
                        case 3:
                            roomSE.Text = cell.nearbyRooms[i].ToString();
                            break;
                        case 4:
                            roomS.Text = cell.nearbyRooms[i].ToString();
                            break;
                        case 5:
                            roomSW.Text = cell.nearbyRooms[i].ToString();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Clear the room fields.  This is used to clear these fields when a game is not in progress.
        /// </summary>
        private void clearRoomLabels()
        {
            roomNW.Text = "";
            roomN.Text = "";
            roomNE.Text = "";
            roomSE.Text = "";
            roomS.Text = "";
            roomSW.Text = "";
            playerRoomField.Text = "";
        }

        /// <summary>
        /// Update the fields on the player stats and progress panel.
        /// </summary>
        private void updatePlayerStats()
        {
            arrowsField.Text = gc.getPlayerArrows().ToString();
            coinsField.Text = gc.getPlayerCoins().ToString();
            turnField.Text = gc.TurnCounter.ToString();
        }

        /// <summary>
        /// Update the message box.  At the end of each turn, a check is made to see if there are any
        /// hazzards around.  If so, display the appropriate message.
        /// </summary>
        private void updateMessages()
        {
            // Since we are going to be using concatenation to build this field, we need to start with
            // a clean slate.
            messageBox.Text = "";

            // Get the bit field that represents the nearby hazzards.  
            byte hazzards = gc.hazzardNearby();

            // If this is non-zero, then there are things we need to warn the player about.
            if (hazzards > 0)
            {
                // Each bit in the bitfield represents one hazzard.  Using bitwise operators determine
                // if these bits are set.  If so, append the appropriate message to the messageBox field.
                if ((hazzards & 1) > 0) { messageBox.Text += "I smell a wumpus" + Environment.NewLine; }
                if ((hazzards & 2) > 0) { messageBox.Text += "I feel a draft" + Environment.NewLine; }
                if ((hazzards & 4) > 0) { messageBox.Text += "Bats nearby" + Environment.NewLine; }
            }
        }

        public void setErrorMessage(string msg)
        {
            errorField.Text = msg;
        }

        public void setHintMessage(string msg)
        {
            hintText.Text = msg;
        }

        public void setRandomHintMessage()
        {
            hintText.Text = gc.trivia.getRandomHint();
        }

        // Routines to handle the clicks on the room fields.

        /// <summary>
        /// User clicked on the SW room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomSW_MouseClick(object sender, MouseEventArgs e)
        {
            Cell.Direction dir = Cell.Direction.SW;
            executeMoveOrShoot(e, dir);
        }

        /// <summary>
        /// User clicked on the S room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomS_MouseClick(object sender, MouseEventArgs e)
        {
            Cell.Direction dir = Cell.Direction.S;
            executeMoveOrShoot(e, dir);
        }

        /// <summary>
        /// User clicked on the SE room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomSE_MouseClick(object sender, MouseEventArgs e)
        {
            Cell.Direction dir = Cell.Direction.SE;
            executeMoveOrShoot(e, dir);
        }

        /// <summary>
        /// User clicked on the NE room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomNE_MouseClick(object sender, MouseEventArgs e)
        {
            Cell.Direction dir = Cell.Direction.NE;
            executeMoveOrShoot(e, dir);
        }

        /// <summary>
        /// User clicked on the N room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomN_MouseClick(object sender, MouseEventArgs e)
        {
            Cell.Direction dir = Cell.Direction.N;
            executeMoveOrShoot(e, dir);
        }

        /// <summary>
        /// User clicked on the NW room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roomNW_MouseClick(object sender, MouseEventArgs e)
        {
            Cell.Direction dir = Cell.Direction.NW;
            executeMoveOrShoot(e, dir);
        }

        /// <summary>
        /// User has clicked on a room.  This helper function determines which button was used,
        /// and implements the proper function (move or shoot).
        /// </summary>
        /// <param name="e">The event arguments (contains the Button value)</param>
        /// <param name="dir">The direction of the room clicked</param>
        private void executeMoveOrShoot(MouseEventArgs e, Cell.Direction dir )
        {
            // Clear the errorField text at the start of each move.
            errorField.Text = "";

            // If the user clicked the Left button, then the user is requesting to move that direction.
            if (e.Button == MouseButtons.Left)
            {
                // Attempt to move the player in the requested direction.  
                // Returns true if the move was successful.
                if (gc.movePlayer(dir))
                {
                    // Move successful, update the game board.
                    updateUI();
                }
                else
                {
                    // Move not successful.  We probably walked into a wall.
                    errorField.Text = "You can't go that way";
                }
            }
            // If the user clicked the Right button, the user is requesting to shoot an arrow in that direction.
            if (e.Button == MouseButtons.Right)
            {
                // Shoot the arrow and collect the result.  The result will be HIT, MISS, or NOPATH.
                // HIT will be handled by the GameControl object.  We only care about MISS and NOPATH.
                GameControl.shootArrowResults result = gc.shootArrow(dir);
                // Set the errorField text appropriate to the results of the shot.
                switch (result)
                {
                    case GameControl.shootArrowResults.MISS:
                        errorField.Text = "Missed";
                        break;
                    case GameControl.shootArrowResults.NOPATH:
                        errorField.Text = "You can't shoot in that direction.";
                        break;
                }
                // The shoot turn is finished so update the fields to show the remaining arrow resources.
                updateUI();
            }
        }

        // Helper function to start a new game.
        private void startNewGame()
        {
            Show(); // Show the UI if it is not visible.
            // Create the NewGame dialog and show it to the user.
            // This dialog updates the playerName and gameSelection members in the GameControl object.
            // Once complete, check to see if the user clicked "OK" (actually labeled "Start").
            NewGameDialog ngd = new NewGameDialog(this);
            DialogResult action = ngd.ShowDialog();
            if (action == DialogResult.OK)
            {
                // User has confirmed they want to start a new game, so update the status panel to
                // show the name of the current player and tell the GameControl object to start 
                // the new game.  Finally update the UI fields and resume waiting for events.
                playerNameField.Text = gc.getPlayerName();
                gc.startGame(GameControl.boardType.NewGame,gc.getPlayerName());
                updateUI();
            }
        }

        private void showTestTriviaDialog(object sender, EventArgs e)
        {
            TriviaTest ttd = new TriviaTest(gc);
            DialogResult action = ttd.ShowDialog();
            if (action == DialogResult.OK)
            {
                updateUI();
            }
            updateUI();
        }

        private void editTriviaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTrivia etd = new EditTrivia(gc.trivia);
        }
    }
}
