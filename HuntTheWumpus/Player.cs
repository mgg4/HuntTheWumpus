using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
    class Player
    {
        // Link back to the GameControl object
        GameControl gc;

        // Player inventory
        int arrowCount;
        int coinCount;
        string playerName;

        // Public interfaces to get/set our object members.
        public string PlayerName
        {
            get
            {
                return playerName;
            }

            set
            {
                playerName = value;
            }
        }

        public int CoinCount
        {
            get
            {
                return coinCount;
            }

            set
            {
                coinCount = value;
            }
        }

        public int ArrowCount
        {
            get
            {
                return arrowCount;
            }

            set
            {
                arrowCount = value;
            }
        }

        public Player (GameControl gc)
        {
            this.gc = gc;
        }

        public Player(GameControl gc, string name)
        {
            // Save the link back to the GameControl
            this.gc = gc;
            playerName = name;
        }

        public void arrowUsed()
        {
            arrowCount--;
        }

        public void coinSpent()
        {
            coinCount--;
        }
    }
}
