using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    /// <summary>
    /// Holds the cards that the player could play during the round
    /// </summary>
    public class PlayerHands
    {
        public Hand Hand { get; private set; }
        public Dictionary<string, Hand> Hands { get; private set; }
        public PlayerHands() 
        {
            Hand = new Hand();
            Hands = new Dictionary<string, Hand>();
        }
    
    }
}
