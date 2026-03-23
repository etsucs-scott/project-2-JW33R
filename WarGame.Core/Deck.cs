using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    /// <summary>
    /// Holds all the cards in the game 
    /// </summary>
    public class Deck
    {
        public Card Card { get; private set; }
        public Stack<Card> Cards { get; private set; }

        public List<Card> ShuffledCards { get; private set; }

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
                    Cards.Push(new Card(rank, suit));
                }
            }

        }
        /// <summary>
        /// Shuffles the cards in random order
        /// </summary>
        public void Shuffle() 
        {
            ShuffledCards = new();
            foreach (Card card in Cards) 
            {
                ShuffledCards.Add(card);
            }
            for (int i = Cards.Count - 1; i > 0; i--) 
            {
                int j = Random.Shared.Next(i + 1);
                (ShuffledCards[i], ShuffledCards[j]) = (ShuffledCards[j], ShuffledCards[i]);
            }
            Cards.Clear();
            foreach (Card card in ShuffledCards) 
            {
                Cards.Push(card);
            }
        }
    }
}
