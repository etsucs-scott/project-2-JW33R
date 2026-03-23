using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    /// <summary>
    /// Represents a playing card with a specific rank and suit.
    /// </summary>
    public class Card : IComparable<Card>
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }
        public Card(Rank rank, Suit suit) 
        {
            Rank = rank;
            Suit = suit;
        }
        /// <summary>
        /// Used to let the code know what it should be comparing
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Card? other)
        {
            if (other == null) 
            {
                return 1;
            }
            return Rank.CompareTo(other.Rank);
        }
    }
}
