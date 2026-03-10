using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    /// <summary>
    /// The main class that runs the game. It deals cards, checks for winners, and handles ties
    /// </summary>
    public class GameEngine
    {
        public Card WinningCard { get; private set; }
        public List<Card> Cards { get; private set; }
        public Deck Deck { get; private set; }
        public Player Player { get; private set; }
        public List<Player> Players { get; private set; }
        public GameEngine()
        {
            WinningCard = new(Rank.Two, Suit.Hearts);
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
                    p.PlayerHands.Hands[$"Player {i + 1}"] = p.PlayerHands.Hand;
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
            Cards.Clear();
            for (int i = 0; i < Players.Count; i++) 
            {
                //if (Players[i].PlayerHands.Hand.Cards.Count > 0)
                //{
                    var card = Players[i].PlayerHands.Hand.Cards.Dequeue();
                    Players[i].PlayedCards.Cards[$"Player {i + 1}"] = card;
                    Cards.Add(card);
                //}
            }
            CheckWinner();
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

        public void CheckWinner() 
        {
            Card winningCard = new(Rank.Two, Suit.Hearts);
            int countOfTies = 0;
            int winningPlayerIndex = 0;
            for (int i = 0; i < Players.Count; i++) 
            {
                if (Cards.Count < 5)
                {
                    var card = Players[i].PlayedCards.Cards[$"Player {i + 1}"];
                    if (card.Rank >= Players[i - RecursiveFormula(i)].PlayedCards.Cards.Values.Max().Rank)
                    {
                        if (Players[i - RecursiveFormula(i)].PlayedCards.Cards.Values.Max().Rank == card.Rank)
                        {
                            countOfTies++;
                            Players[i].SetTied(true);
                        }
                        winningCard = card;
                        winningPlayerIndex = i;
                    }
                    else if (winningCard.Rank == Rank.Two && winningCard.Suit == Suit.Hearts)
                    {
                        winningCard = card;
                    }
                }
                else 
                {
                    Players[i].PlayedCards.Cards.Clear();
                    Players[i].SetTied(false);
                }
            }
            WinningCard = winningCard;
            if (countOfTies > 1)
            {
                StartWar(countOfTies);
            }
            else 
            {
                GiveWinnerCards(winningPlayerIndex);
            }
            
        }
        /// <summary>
        /// Returns the winning card 
        /// </summary>
        /// <param name="winningCard">Takes in the winning card</param>
        /// <returns></returns>
        public string PrintWinner(Card winningCard) 
        {
            return $"Player {winningCard.Rank} of {winningCard.Suit} wins the round!";
        }
        public void StartWar(int countOfTies) 
        {
            for (int i = 0; i < Players.Count; i++) 
            {
                if (Players[i].IsTied == true)
                {
                    Players[i].PlayedCards.Cards[$"Player {i + 1}"] = Players[i].PlayerHands.Hand.Cards.Dequeue();
                    Cards.Add(Players[i].PlayedCards.Cards[$"Player {i + 1}"]);
                }
            }
            CheckWinner();
            CheckWinner();
        }
        public void GiveWinnerCards(int index) 
        {
            for (int i = 0; i < Cards.Count; i++) 
            {
                Players[index].PlayerHands.Hand.Cards.Enqueue(Cards[i]);
            }
        }
    }
}
