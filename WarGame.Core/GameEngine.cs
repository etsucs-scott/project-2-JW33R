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
        public List<Player> Players { get; private set; }
        public GameEngine()
        {
            Players = new List<Player>();
            Deck = new Deck();
            PlayedCards = new PlayedCards();
        }

        public void StartGame(int playerCount)
        {
            Deck.Shuffle();
            PlayerCount(playerCount);
            DealCards();
        }

        public void DealCards()
        {
            foreach (Player p in Players)
            {
                p.PlayerHands.Hand.Cards.Enqueue(Deck.Cards.Pop());
            }


        }
        public void PlayerCount(int playerCount)
        {
            for (int i = 0; i < playerCount; i++)
            {
                Player player = new Player();
                Players.Add(player);
            }
        }
    }
}
