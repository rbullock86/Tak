using System;

namespace Tak
{
    public class Player
    {
        public int pNumber { get; set; }
        public int Stones{ get; set; }
        public int CapStone { get; set; }
        public Game game { get; set; }

        public Player(Game game, int pnum)
        {
            this.game = game;
            this.pNumber = pnum;
            this.Stones = 21;
            this.CapStone = 1;
        }
    }
}