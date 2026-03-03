using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class PlayerHands
    {
        public Dictionary<string, Hand> Hands { get; private set; }
        public PlayerHands() 
        {
            Hands = new Dictionary<string, Hand>();
        }
    }
}
