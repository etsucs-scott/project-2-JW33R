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
                if (gameEngine.Cards.Count > 4)
                {
                    break;
                }
                Console.WriteLine($"Player {playerIndex} played {gameEngine.Cards[i].Rank} of {gameEngine.Cards[i].Suit}");
                playerIndex++;
                
            }
            if (countOfTies >= 2) 
            {
                DisplayTiedCard();
            }
            
        }
        public void DisplayTiedCard() 
        {
            //int playerIndex = 1;
            //for (int i = 0; i < gameEngine.Players.Count; i++)
            //{
            //    if (gameEngine.Players[i].IsTied) 
            //    {
            //        Console.WriteLine("Hello");
            //        Console.WriteLine($"Player {playerIndex} played {gameEngine.Cards[i].Rank} of {gameEngine.Cards[i].Suit}");
            //    }
            //    playerIndex++;
            //    if (gameEngine.Cards.Count > 4) 
            //    {
            //        break;
            //    }
            //}
            foreach (var player in gameEngine.Players)
            {
                foreach (var item in player.PlayedCards.Cards)
                {
                    if (gameEngine.Cards.Count > 4)
                    {
                        
                    }
                    Console.WriteLine($"{item.Key} played the {item.Value.Rank} of {item.Value.Suit}");
                    
                }

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
