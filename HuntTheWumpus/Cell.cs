using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuntTheWumpus
{
    /// <summary>
    /// The Cell class deals with an individual room in the cave.  Most of this involves
    /// computing the numbers of the adjacent rooms.  The Cell class is heavily used during
    /// initialization of the Cave object.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Class members
        /// Direction   - an enum defining the directions which could be taken from the cell
        /// roomNbr     - the current room number of this cell
        /// nearbyRooms - the array of adjacent and accessible rooms
        /// </summary>
        public enum Direction { NW,N,NE,SE,S,SW }
        int roomNbr;
        public int[] nearbyRooms;

        /// <summary>
        /// The generic constructor for a Cell object.  This will never be called.
        /// </summary>
        public Cell() { }

        /// <summary>
        /// The constructor for a Cell object.  Build an object to represent the desired room.
        /// All adjacent rooms will be accessible on construction.  In order for the Cave object
        /// to be valid, 3 to 5 of these tunnels will need to be blocked or closed.
        /// </summary>
        /// <param name="roomNbr">The room number the Cell object should represent.</param>
        public Cell(int roomNbr)
        {
            // Validate our parameter.
            if (roomNbr < 1 || roomNbr > 30)
            {
                // This should never happen, but since it did, give the user the bad news.
                System.ArgumentException argEx = new System.ArgumentException("roomNbr out of range");
                throw argEx;
            }
            this.roomNbr = roomNbr;
            // Create the array of adjacent rooms
            nearbyRooms = new int[6];
            int i;
            for (i=0; i<6; i++)
            {
                this.nearbyRooms[i] = computeDestinationRoomNbr(roomNbr, i);
            }
            // And with that, the Cell is created.
        }

        /// <summary>
        /// Compute the room number that would be reached when travelling in
        /// the specified direction.
        /// </summary>
        /// <param name="roomNbr">The current room number.</param>
        /// <param name="direction">The direction to travel.</param>
        /// <returns>An integer between 1 and 30 represnting the destination room number.</returns>
        private int computeDestinationRoomNbr(int roomNbr, Direction direction)
        {
            int offset = 0;
            int destRoom = 0;

            // Regardless of where the cell is, N and S are always the same offset.
            if (direction == Direction.N) { offset = -6; };
            if (direction == Direction.S) { offset = +6; };

            // Use modulus division to check for first or last row.  
            // First column will have a modulus of 1, and last will be 0.
            // The cells in these columns have different rules.
            if ((roomNbr % 6) < 2)
            {
                // This is the first or last column.
                switch (direction)
                {
                    case Direction.NW:
                        offset = -1;
                        break;
                    case Direction.NE:
                        offset = -5;
                        break;
                    case Direction.SE:
                        offset = +1;
                        break;
                    case Direction.SW:
                        offset = +5;
                        break;
                }
            }
            else  // Not first or last column
            {
                // For cells not in the first or last column, the offsets are different
                // depending on whether the cell number is odd or even.  Use modulus again
                // to determine which set of rules to apply.
                if ((roomNbr % 2) == 0)
                {
                    // Room number is even
                    switch (direction)
                    {
                        case Direction.NW:
                            offset = -1;
                            break;
                        case Direction.NE:
                            offset = +1;
                            break;
                        case Direction.SE:
                            offset = +7;
                            break;
                        case Direction.SW:
                            offset = +5;
                            break;
                    }
                }
                else
                {
                    // Room number is odd
                    switch (direction)
                    {
                        case Direction.NW:
                            offset = -7;
                            break;
                        case Direction.NE:
                            offset = -5;
                            break;
                        case Direction.SE:
                            offset = +1;
                            break;
                        case Direction.SW:
                            offset = -1;
                            break;
                    }
                }
            }
            // This should never happen, but if we do happen to fall through 
            // the entire structure above and not catch code to set the offset,
            // then we need to blow things up.
            if (offset == 0)
            {
                System.ArgumentException argEx = new System.ArgumentException("Invalid offset found");
                throw argEx;
            }
            // We appear to have a valid offset, so it's time to compute where we would land.
            destRoom = roomNbr + offset;
            // Adjust for going off the edge of the map.  This creates the wrap-around.
            if (destRoom > 30) destRoom -= 30;
            if (destRoom <  1) destRoom += 30;
            // Return the computed value.
            return destRoom;
        }

        /// <summary>
        /// Provide an alternative calling method for computing the destination room number,
        /// using an integer to represent the desired direction.
        /// </summary>
        /// <param name="roomNbr">The current room number.</param>
        /// <param name="dir">The direction to travel, expressed as an int.</param>
        /// <returns>An integer between 1 and 30 represnting the destination room number.</returns>
        private int computeDestinationRoomNbr(int roomNbr, int dir)
        {
            return computeDestinationRoomNbr(roomNbr, (Direction) dir);
        }

        /// <summary>
        /// The public interface for asking what room would be in a given direction
        /// from the room represented by this Cell object.
        /// </summary>
        /// <param name="direction">The direction to look</param>
        /// <returns>An integer between 1 and 30 represnting the destination room number.</returns>
        public int roomTo(Direction direction)
        {
            return nearbyRooms[(int)direction];
        }

        /// <summary>
        /// Close off the tunnel to the adjacent room in the specified direction.
        /// This is used during the process of building a valid Cave object.
        /// 
        /// NOTE: This function only closes one-half of the tunnel.  The tunnel
        /// back from the other room must also be closed.  It is the calling
        /// function's job to ensure both directions of the tunnel are closed.
        /// </summary>
        /// <param name="dir">The direction of the tunnel to close.</param>
        public void closeTunnel (Direction dir)
        {
            // A destination room less than zero indicates no tunnel to that room.
            nearbyRooms[(int) dir] = -1; 
        }

        /// <summary>
        /// Reopen a tunnel that has been closed off.  May never be called, but
        /// provides the orthagonal function to closeTunnel().
        /// 
        /// NOTE: This function only opens one-half of the tunnel.  The tunnel
        /// back from the other room must also be opened.  It is the calling
        /// function's job to ensure both directions of the tunnel are opened.

        /// </summary>
        /// <param name="dir">The direction of the tunnel to open.</param>
        public void openTunnel (Direction dir)
        {
            // To restore the tunnel pathway, we need to compute where we would have 
            // landed before the tunnel was closed.
            nearbyRooms[(int) dir] = computeDestinationRoomNbr(roomNbr, dir);  // Open the pathway to the proper room.
        }

        /// <summary>
        /// Count the number of active tunnels for a room.  This is used to determine 
        /// if the configuration of the cell is valid (between 1 and 3 tunnels).
        /// </summary>
        /// <returns>An integer representing the number of open tunnels in the cell</returns>
        public int nbrOpenTunnels()
        {
            int i;
            int count = 0;
            for (i=0;i<6;i++)
            {
                if (nearbyRooms[i] > 0) { count++; }
            }
            return count;
        }     
    }
}
