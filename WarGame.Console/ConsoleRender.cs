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
            int playerIndex = 1;
            for (int i = 0; i < gameEngine.Cards.Count; i++)
            {
                if (i > gameEngine.Players.Count)
                {
                    break;
                }
                Console.WriteLine($"Player {playerIndex} played {gameEngine.Cards[i].Rank} of {gameEngine.Cards[i].Suit}");
                playerIndex++;
                
            }
            //if (countOfTies >= 2) 
            //{
                DisplayTiedCard();
            //}
            
        }
        public void DisplayTiedCard() 
        {
            foreach (var player in gameEngine.Players)
            {
                int index = 1;
                if (gameEngine.Cards.Count > gameEngine.Players.Count)
                {

                    if (player.PlayedCards.Cards.ContainsKey($"Player {index + 1}")) 
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
