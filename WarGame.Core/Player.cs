using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    public class Player
    {
        public bool IsTied { get; private set; }
        public PlayerHands PlayerHands { get; private set; }
        public PlayedCards PlayedCards { get; private set; }

        public Player()
        {
            PlayerHands = new PlayerHands();
            PlayedCards = new PlayedCards();
        }

        public void SetTied(bool isTied)
        {
            IsTied = isTied;
        }
    }
}
