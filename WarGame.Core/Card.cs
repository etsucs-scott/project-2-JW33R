using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }
        public Card(Suit suit, Rank rank) 
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
