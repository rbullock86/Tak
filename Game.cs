using System;
using System.Collections.Generic;

namespace Tak
{
    public class Game
    {
        public int TurnNumber { get; set; }
        public bool PlayerOneTurn { get; set; }       // If true it is player one's turn, else it is player two's turn
        public bool FirstTurn { get; set; }           // The first turn has special rules, each player places an opponent's piece
        public Board board { get; set; }       // Holds the tiles
        public GFX gfx { get; set; }                   // Draws Stuff
        public InputManager im { get; set; }           // Manages keyboard entries
        public bool waitingForMove { get; set; }
        public bool gameOver { get; set; }
        public Player P1 { get; set; }
        public Player P2 { get; set; }

        public Game()
        {
            this.TurnNumber = 0;
            this.PlayerOneTurn = true;
            this.FirstTurn = true;
            this.gfx = new GFX(this);
            this.im = im;
            this.board = new Board(this);
            this.P1 = new Player(this, 1);
            this.P2 = new Player(this, 2);
            gfx.DrawBoard();
            gfx.UpdateInventories();
            this.im = new InputManager(this);
            this.waitingForMove = true;
            this.gameOver = false;
            GameLoop();
        }
        public void GameLoop()
        {
            while (this.gameOver == false)
            {
                if (waitingForMove == true)
                {
                    im.GetKey();
                }
            }
        }
        public void PlaceFlat(int pNum, Tile tile)
        {
            if (pNum == 1)
            {
                this.P1.Stones--;
            }
            else
            {
                this.P2.Stones--;
            }
            tile.Top = 1;
            tile.ControllingPlayer = pNum;
            tile.TileState.Add(pNum.ToString());
            gfx.DrawTile(tile);
        }
    }
}