using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class Card : IComparable<Card>
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }
        public Card(Rank rank, Suit suit) 
        {
            Rank = rank;
            Suit = suit;
        }

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
