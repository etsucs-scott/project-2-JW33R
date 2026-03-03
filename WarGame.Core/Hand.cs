using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class Hand
    {
        public Queue<Card> Cards { get; private set; }
        public Hand() 
        {
            Cards = new Queue<Card>();
        }
    }
}
