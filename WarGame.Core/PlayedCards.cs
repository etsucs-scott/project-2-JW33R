using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class PlayedCards
    {
        public Dictionary<string, Card> Cards { get; private set; }
        public PlayedCards() 
        {
            Cards = new Dictionary<string, Card>();
        }
    }
}
