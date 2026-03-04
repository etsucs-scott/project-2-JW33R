using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class GameEngine
    {
        public Deck Deck { get; private set; }
        public Player Player { get; private set; }
        public List<Player> Players { get; private set; }
        public GameEngine()
        {
            Players = new List<Player>();
            Deck = new Deck();
        }

        public void StartGame(int playerCount)
        {
            Deck.Shuffle();
            PlayerCount(playerCount);
            DealCards();
        }
        public void DealCards()
        {
            var topCard = Deck.Cards.Peek();
            while (Deck.Cards.Count > 0) 
            {
                foreach (Player p in Players)
                {
                    if (Deck.Cards.Count == 0)
                    {
                        break;
                    }
                    topCard = Deck.Cards.Pop();
                    p.PlayerHands.Hand.Cards.Enqueue(topCard);
                    p.PlayerHands.Hands["Player " + (Players.IndexOf(p) + 1)] = p.PlayerHands.Hand;
                }
            }
        }
        /// <summary>
        /// Gets the number of players from the StartGame method and creates that many player objects and adds them to the Players list.
        /// </summary>
        /// <param name="playerCount">The amount of players entered in by user taken from StartGame function</param>
        public void PlayerCount(int playerCount)
        {
            for (int i = 0; i < playerCount; i++)
            {
                Player player = new Player();
                Players.Add(player);
            }
        }

        public void PlayRound() 
        {
            foreach (Player p in Players) 
            {
                p.PlayedCards.Cards["Player " + (Players.IndexOf(p) + 1)] = p.PlayerHands.Hand.Cards.Dequeue();
            }
        }

        public Card CheckWinner() 
        {
            Card winningCard = new(Suit.Hearts, Rank.Three);
            foreach (Player p in Players) 
            {
                winningCard = p.PlayedCards.Cards.Values.Max();
            }
            return winningCard;
        }
        //public string GetCardValue() 
        //{
        //    return Player.PlayedCards.Cards.Keys.ToString();

        //}
        public void CheckForWar() 
        {
            foreach (Player p in Players) 
            {
                if (p.PlayedCards.Cards["Player " + (Players.IndexOf(p) + 1)].Rank == CheckWinner().Rank) 
                {
                    
                }
            }
        }
      
    }
}
