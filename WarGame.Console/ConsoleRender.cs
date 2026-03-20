using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarGame.Core;

namespace WarGame.Cli
{
    public class ConsoleRender
    {
        public GameEngine gameEngine { get; private set; }
        public Deck deck { get; private set; }

        public ConsoleRender()
        {
            gameEngine = new GameEngine();
            deck = new Deck();
        }
        public void DisplayRoundCards(int countOfTies) 
        {
            int cardIndex = 0;
            foreach (var player in gameEngine.Players)
            {
                foreach (var item in player.PlayerHands.Hands)
                {
                    Console.WriteLine($"{item.Key} Played {gameEngine.Cards[cardIndex].Rank} of {gameEngine.Cards[cardIndex].Suit} ");

                }
                cardIndex++;
            }
            if (countOfTies > 1)
            {
                DisplayTiedCard();
            }
            
            
        }
        public void DisplayTiedCard() 
        {
            int index = 0;
            foreach (var player in gameEngine.TiedPlayers)
            {
                if (gameEngine.TiedPlayers.Count <= 1)
                {
                    Console.WriteLine("In Disolay");
                    break;
                }
                bool playerIndex = player.PlayedCards.Cards.ContainsKey($"Player {index + 1}");
                if (gameEngine.Cards.Count > gameEngine.Players.Count)
                {

                    if (playerIndex) 
                    {
                        Console.WriteLine($"Player {index + 1} played the {player.PlayedCards.Cards[$"Player {index + 1}"].Rank} of {player.PlayedCards.Cards[$"Player {index + 1}"].Suit}");
                    }

                }
                index++;
            }
        }
        public void DisplayPlayerCardCount() 
        {
            foreach (var player in gameEngine.Players) 
            {
                foreach (var item in player.PlayerHands.Hands) 
                {
                    Console.Write($"{item.Key}: ({item.Value.Cards.Count}) | ");
                    
                }
                
            }
        }
    }
}
