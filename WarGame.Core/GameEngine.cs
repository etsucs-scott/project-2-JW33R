using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class GameEngine
    {
        public Deck Deck { get; private set; }
        public PlayedCards PlayedCards { get; private set; }
        public Player Player { get; private set; }
        public GameEngine() 
        {
            Deck = new Deck();
            PlayedCards = new PlayedCards();
            Player = new Player();
        }

        public void StartGame() 
        {
            Deck.Shuffle();
        }

        public void DealCards(Player player) 
        {
            foreach (Card card in Deck.Cards)
            {
                //player.PlayerHands.Hands["Player1"] = card;
            }

        }
    }
}
