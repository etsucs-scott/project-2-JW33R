using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarGame.Core;

namespace WarGame.Cli
{
    /// <summary>
    /// Used to tell the Program class what to render
    /// </summary>
    public class ConsoleRender
    {
        public GameEngine GameEngine { get; private set; }
        public Deck Deck { get; private set; }

        public ConsoleRender()
        {
            GameEngine = new GameEngine();
            Deck = new Deck();
        }
        /// <summary>
        /// Shows the current round cards
        /// </summary>
        public void DisplayRoundCards() 
        {
            int cardIndex = 0;
            foreach (var player in GameEngine.Players)
            {
                foreach (var item in player.PlayerHands.Hands)
                {
                    Console.WriteLine($"{item.Key}: {GameEngine.Cards[cardIndex].Rank}");

                }
                cardIndex++;
            }
            
            
        }
        /// <summary>
        /// Shows the tied cards between the players if any
        /// </summary>
        public void DisplayTiedCard()
        {
            Console.WriteLine($"{GameEngine.RoundResult}");
            
        }
        /// <summary>
        /// Shows the current Player Card Count at the end of the round
        /// </summary>
        public void DisplayPlayerCardCount() 
        {
            foreach (var player in GameEngine.Players) 
            {
                foreach (var item in player.PlayerHands.Hands) 
                {
                    Console.Write($"{item.Key}: ({item.Value.Cards.Count}),");
                    
                }
                
            }
        }
        /// <summary>
        /// Shows the player with the highest card or highest cards if mulitple players
        /// </summary>
        /// <param name="round"></param>
        /// <param name="roundCap"></param>
        public void DisplayFinalCard(int round, int roundCap)
        {
            if (round >= roundCap)
            {
                var highestCard = GameEngine.HighestCards();
                foreach (Player player in highestCard)
                {
                    Console.Write($"{player.Name} ");
                }
                if (highestCard.Count > 1)
                {
                    Console.Write($"tied for first place");
                }
                else
                {
                    Console.WriteLine("won this game!");
                }
            }
        }
    }
}
