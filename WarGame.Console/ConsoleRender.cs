using System;
using System.Collections.Generic;
using System.Linq;
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
        public void DisplayRoundCards(int playerCount) 
        {
            int playerIndex = 1;
            for (int i = 0; i < gameEngine.Cards.Count; i++)
            {
                Console.WriteLine($"Player {playerIndex} played {gameEngine.Cards[i].Rank} of {gameEngine.Cards[i].Suit}");
                playerIndex++;
                if (playerIndex > 4)
                {
                    playerIndex = 1;
                }
            }
        }
    }
}
