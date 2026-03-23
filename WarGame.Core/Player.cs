using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame.Core
{
    /// <summary>
    /// The Player that is playing the game
    /// </summary>
    public class Player
    {
        public int IndexNumber { get; private set; }
        public string Name { get; private set; }
        public PlayerHands PlayerHands { get; private set; }
        public PlayedCards PlayedCards { get; private set; }

        public Player()
        {
            PlayerHands = new PlayerHands();
            PlayedCards = new PlayedCards();
        }
        /// <summary>
        /// Sets the value of the IndexNumber property used for determining which player I'm dealing with
        /// </summary>
        /// <param name="index"></param>
        public void SetIndexNumber(int index)
        {
            IndexNumber = index;
        }
        /// <summary>
        /// Sets the value of the Name property to name each player
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            Name = name;
        }
    }
}
