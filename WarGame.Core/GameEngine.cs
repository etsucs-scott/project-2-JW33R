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
        public List<Card> Cards { get; private set; }
        public Deck Deck { get; private set; }
        public Player Player { get; private set; }
        public List<Player> Players { get; private set; }
        public GameEngine()
        {
            Cards = new List<Card>();
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
                for (int i = 0; i < Players.Count; i++)
                {
                    Player p = Players[i];
                    if (Deck.Cards.Count == 0)
                    {
                        break;
                    }
                    topCard = Deck.Cards.Pop();
                    p.PlayerHands.Hand.Cards.Enqueue(topCard);
                    p.PlayerHands.Hands["Player " + (i + 1)] = p.PlayerHands.Hand;
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
            for (int i = 0; i < Players.Count; i++) 
            {
                var card = Players[i].PlayerHands.Hand.Cards.Dequeue();
                Players[i].PlayedCards.Cards["Player " + (i + 1)] = card;
                Cards.Add(card);
            }
            CheckWinner();
            //CheckForWar();
        }
        /// <summary>
        /// Used to get the previous index in a sequence
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int RecursiveFormula(int count) 
        {
            if (count == 0)
            {
                return 0;
            }
            else if (count == 1)
            {
                return 1;
            }
            else 
            {
                return RecursiveFormula(count - 1);
            }
        }

        public Card CheckWinner() 
        {
            Card winningCard = new(Rank.Two, Suit.Hearts);
            for (int i = 0; i < Players.Count; i++) 
            {
                winningCard = Players[i].PlayedCards.Cards.Values.Max();
                if (winningCard.Rank > Players[i - RecursiveFormula(i)].PlayedCards.Cards.Values.Max().Rank) 
                {
                    winningCard = Players[i].PlayedCards.Cards.Values.Max();
                }
            }
            return winningCard;
        }
        public void CheckForWar() 
        {
            for (int i = 0; i < Players.Count; i++) 
            {
                int counter = 0;
                Player p = Players[i];
                if (p.PlayedCards.Cards[$"Player {i + 1}"].Rank == CheckWinner().Rank)
                {
                    counter++;
                }
                if (counter > 1 && i == Players.Count - 1) 
                {
                    p.PlayedCards.Cards[$"Player {i + 1}"] = p.PlayerHands.Hand.Cards.Dequeue();
                    Cards.Add(p.PlayedCards.Cards["Player " + (i + 1)]);
                }
            }
        }
        public void CheckForNoCards() 
        {
            
        }
        public void GiveCardsToWinner() 
        {
            
        }
      
    }
}
