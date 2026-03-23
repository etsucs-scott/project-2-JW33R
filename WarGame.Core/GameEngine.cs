using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection;
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
        public string RoundResult { get; private set; }
        public List<Player> TiedPlayers { get; private set; }
        public Card WinningCard { get; private set; }
        public List<Card> Cards { get; private set; }
        public Deck Deck { get; private set; }
        public List<Player> Players { get; private set; }
        public GameEngine()
        {
            WinningCard = new(Rank.Two, Suit.Hearts);
            Cards = new List<Card>();
            Players = new List<Player>();
            Deck = new Deck();
            TiedPlayers = new();
        }
        /// <summary>
        /// Function that shuffles the deck, gets player count and deals cards
        /// </summary>
        /// <param name="playerCount"></param>
        public void StartGame(int playerCount)
        {
            Deck.Shuffle();
            PlayerCount(playerCount);
            DealCards();
        }
        /// <summary>
        /// Deals cards to each player
        /// </summary>
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
                player.SetName($"Player {i + 1}");
                Players.Add(player);
            }
        }
        /// <summary>
        /// Plays a round of war and deals the cards to each player
        /// </summary>
        public void PlayRound() 
        {
            RoundResult = string.Empty;
            TiedPlayers.Clear();
            Cards.Clear();
            for (int i = 0; i < Players.Count; i++) 
            {
                if (Players[i].PlayerHands.Hand.Cards.Count > 0)
                {
                    Cards.Add(Players[i].PlayerHands.Hand.Cards.Peek());
                    Players[i].PlayedCards.Cards[$"Player {i + 1}"] = Players[i].PlayerHands.Hand.Cards.Dequeue();
                    
                }
                Players[i].SetIndexNumber(0);
            }
            CheckWinnerIfNoTie();
            KickPlayer();
        }
        /// <summary>
        /// Checks to see who the winner is without a tie
        /// </summary>
        public void CheckWinnerIfNoTie() 
        {
            int winningPlayerIndex = 0;
            WinningCard = Cards.Max();
            for (int i = 0; i < Players.Count; i++) 
            {
                if (Players[i].PlayedCards.Cards[$"Player {i + 1}"].Rank == WinningCard.Rank)
                {
                    winningPlayerIndex = i;
                }
            }
            
            if (IsTied(WinningCard))
            {
                StartWar();
            }
            else 
            {
                GiveWinnerCards(winningPlayerIndex);
            }
            
        }
        /// <summary>
        /// Checks to see the winner is assuming there is a tie
        /// </summary>
        public void CheckWinnerIfTie()
        {
            int winningPlayerIndex = 0;
            WinningCard = GetMaxCard();
            foreach (Player player in TiedPlayers)
            {
                if (player.PlayedCards.Cards[$"Player {player.IndexNumber + 1}"].Rank == WinningCard.Rank)
                {
                    winningPlayerIndex = player.IndexNumber;
                }
            }
            if (IsTied(WinningCard))
            {
                StartWar();
            }
            else
            {
                GiveWinnerCards(winningPlayerIndex);
            }
                
        }
        /// <summary>
        /// Gets the Max Card for the tied players
        /// </summary>
        /// <returns></returns>
        public Card GetMaxCard()
        {
            Card winningCard = null;
            for (int i = 0; i < TiedPlayers.Count; i++)
            {
                if (i + 1 < TiedPlayers.Count)
                {
                    if (TiedPlayers[i + 1].PlayedCards.Cards.Max().Value.Rank > TiedPlayers[i].PlayedCards.Cards.Max().Value.Rank)
                    {
                        winningCard = TiedPlayers[i + 1].PlayedCards.Cards.Max().Value;
                    }
                    else
                    {
                        winningCard = TiedPlayers[i].PlayedCards.Cards.Max().Value;
                    }
                }
                else
                {
                    break;
                }
            }
            return winningCard;
        }
        /// <summary>
        /// Returns the winning card 
        /// </summary>
        /// <param name="winningCard">Takes in the winning card</param>
        /// <returns></returns>
        public string PrintWinner(Card winningCard) 
        {
            return $"{winningCard.Rank} of {winningCard.Suit} wins the round!";
        }
        /// <summary>
        /// Starts to deal out cards to the players that tied
        /// </summary>
        public void StartWar()
        {
            foreach (Player player in TiedPlayers)
            {
                if (player.PlayerHands.Hand.Cards.Count > 0)
                {
                    Cards.Add(player.PlayerHands.Hand.Cards.Peek());
                    RoundResult += $"\n{player.Name}: {player.PlayerHands.Hand.Cards.Peek().Rank}";
                    player.PlayedCards.Cards[$"Player {player.IndexNumber + 1}"] = player.PlayerHands.Hand.Cards.Dequeue(); 
                    
                }
            }
            CheckWinnerIfTie();
        }
        /// <summary>
        /// Gets the player with the highest card count
        /// </summary>
        /// <returns></returns>
        public List<Player> HighestCards()
        {
            int highestCard = 0;
            Player highestCardPlayer = null;
            List<Player> highestCardPlayers = new();
            foreach (Player player in Players)
            {
                if (player.PlayerHands.Hand.Cards.Count > highestCard)
                {
                    highestCard = player.PlayerHands.Hand.Cards.Count;
                    highestCardPlayer = player;
                }
                if (player.PlayerHands.Hand.Cards.Count == highestCard && !highestCardPlayers.Contains(player))
                {
                    highestCardPlayers.Add(player);
                }
            }
            return highestCardPlayers;
        }
        /// <summary>
        /// Gives the winner the cards from the pot
        /// </summary>
        /// <param name="index"></param>
        public void GiveWinnerCards(int index) 
        {
            for (int i = 0; i < Cards.Count; i++) 
            {
                Players[index].PlayerHands.Hand.Cards.Enqueue(Cards[i]);
            }
        }
        /// <summary>
        /// Kicks a player from the game
        /// </summary>
        public void KickPlayer()
        {
            int playerIndex = 0;
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].PlayerHands.Hand.Cards.Count <= 0)
                {
                    playerIndex = i;
                }
            }
            if (Players[playerIndex].PlayerHands.Hand.Cards.Count <= 0)
            {
                Players.Remove(Players[playerIndex]);
            }

        }
        /// <summary>
        /// Checks to see if the player is tied with another player
        /// </summary>
        /// <param name="winningCard"></param>
        /// <returns></returns>
        public bool IsTied(Card winningCard)
        {
            TiedPlayers.Clear();
            int i = 0;
            foreach (Player player in Players) 
            {
                if (player.PlayedCards.Cards.ContainsKey($"Player {i + 1}"))
                {
                    if (winningCard.Rank == player.PlayedCards.Cards[$"Player {i + 1}"].Rank)
                    {
                        TiedPlayers.Add(player);
                        player.SetIndexNumber(i);

                    }
                }
                player.PlayedCards.Cards.Clear();
                i++;
            }
            if (TiedPlayers.Count >= 2)
            {
                return true;
            }
            else 
            {
                return false;
            }
                
            
        }
        /// <summary>
        /// Ends the game if a player has 52 cards
        /// </summary>
        /// <returns></returns>
        public bool EndGame()
        {
            foreach (Player player in Players)
            {
                if (player.PlayerHands.Hand.Cards.Count == 52)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
    }
}
