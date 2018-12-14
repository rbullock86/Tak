// This is a data class for the board
// It builds the board 


using System;
using System.Collections.Generic;

namespace Tak
{
    public class Board
    {
        public List<Tile> tiles = new List<Tile>();
        public Game game { get; set; }
        public Board(Game game)
        {
            this.game = game;
            for(int y = 0; y < 5; y++)
            {
                for(int x = 0; x < 5; x++)
                {
                    if((x + y) % 2 == 0){
                        tiles.Add(new Tile(x, y, ConsoleColor.DarkGreen));
                    } else {
                        tiles.Add(new Tile(x, y, ConsoleColor.Cyan));
                    }
                }
            }
        }
    }
}