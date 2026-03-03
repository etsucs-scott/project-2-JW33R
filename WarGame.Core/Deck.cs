using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class Deck
    {
        public Card Card { get; private set; }
        public Stack<Card> Cards { get; private set; }

        /// <summary>
        /// Initializes a new Stack of Cards with 52 Cards
        /// </summary>
        public Deck() 
        {
            Cards = new Stack<Card>();
            foreach (Suit suit in Enum.GetValues<Suit>()) 
            {
                foreach (Rank rank in Enum.GetValues<Rank>()) 
                {
                    Cards.Push(new Card(suit, rank));
                }
            }

        }

        public void Shuffle() 
        {
            Random random = new Random();
            foreach (var c in Cards) 
            {
                Cards.Push(c);
            }
        }
    }
}
