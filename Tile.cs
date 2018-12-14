// This is the Tile Data class that holds data for current pieces on a given tile
// and potentially other stuff

using System;
using System.Collections.Generic;

namespace Tak
{
    public class Tile
    {
        public static int TileCount = 0;
        public ConsoleColor TileColor { get; set; }
        public List<string> TileState = new List<string>();
        public int ControllingPlayer { get; set; }
        public int TileX { get; private set; }
        public int TileY { get; private set; }
        public int Top { get; set; }
        public bool HasCursor {get; set;}

        public Tile(int tileX, int tileY, ConsoleColor tileColor)
        {
            this.HasCursor = false;
            this.TileColor = tileColor;
            this.Top = 0;
            this.TileX = tileX;
            this.TileY = tileY;
            this.ControllingPlayer = 0;
            TileCount++;
        }
    }
}