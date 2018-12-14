using System;

namespace Tak
{
    public class InputManager
    {
        public int BigCursorX { get; set; }
        public int BigCursorY { get; set; }
        public Game game { get; set; }

        public InputManager(Game game)
        {
            this.game = game;
            CursorInit();
        }
        public void CursorInit()
        {
            BigCursorX = 0;
            BigCursorY = 0;
            game.board.tiles[0].HasCursor = true;
            game.gfx.DrawTile(game.board.tiles[0]);
        }
        public void GetKey(){
            int currentPlayer = ((game.TurnNumber % 2) + 1);
            ConsoleKey keyPressed = Console.ReadKey(true).Key;
            if (keyPressed == ConsoleKey.RightArrow)
            {
                if (BigCursorX < 4)
                {
                    game.gfx.ClearContext();
                    game.board.tiles[BigCursorX + BigCursorY*5].HasCursor = false;
                    game.gfx.DrawTile(game.board.tiles[BigCursorX + BigCursorY*5]);
                    BigCursorX++;
                    game.board.tiles[BigCursorX + BigCursorY*5].HasCursor = true;
                    game.gfx.DrawTile(game.board.tiles[BigCursorX + BigCursorY*5]);
                    game.gfx.BuildContextMenu(currentPlayer, game.board.tiles[BigCursorX + 5*BigCursorY]);
                }
            }
            else if (keyPressed == ConsoleKey.LeftArrow)
            {
                if (BigCursorX > 0)
                {
                    game.gfx.ClearContext();
                    game.board.tiles[BigCursorX + BigCursorY*5].HasCursor = false;
                    game.gfx.DrawTile(game.board.tiles[BigCursorX + BigCursorY*5]);
                    BigCursorX--;
                    game.board.tiles[BigCursorX + BigCursorY*5].HasCursor = true;
                    game.gfx.DrawTile(game.board.tiles[BigCursorX + BigCursorY*5]);
                    game.gfx.BuildContextMenu(currentPlayer, game.board.tiles[BigCursorX + 5*BigCursorY]);
                }
            }
            else if (keyPressed == ConsoleKey.UpArrow)
            {
                if (BigCursorY > 0)
                {
                    game.gfx.ClearContext();
                    game.board.tiles[BigCursorX + BigCursorY*5].HasCursor = false;
                    game.gfx.DrawTile(game.board.tiles[BigCursorX + BigCursorY*5]);
                    BigCursorY--;
                    game.board.tiles[BigCursorX + BigCursorY*5].HasCursor = true;
                    game.gfx.DrawTile(game.board.tiles[BigCursorX + BigCursorY*5]);
                    game.gfx.BuildContextMenu(currentPlayer, game.board.tiles[BigCursorX + 5*BigCursorY]);
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                if (BigCursorY < 4)
                {
                    game.gfx.ClearContext();
                    game.board.tiles[BigCursorX + BigCursorY*5].HasCursor = false;
                    game.gfx.DrawTile(game.board.tiles[BigCursorX + BigCursorY*5]);
                    BigCursorY++;
                    game.board.tiles[BigCursorX + BigCursorY*5].HasCursor = true;
                    game.gfx.DrawTile(game.board.tiles[BigCursorX + BigCursorY*5]);
                    game.gfx.BuildContextMenu(currentPlayer, game.board.tiles[BigCursorX + 5*BigCursorY]);
                }
            }
            else if (keyPressed == ConsoleKey.F)
            {
                Tile tile = game.board.tiles[BigCursorX + BigCursorY*5];
                // First turn case
                if ( tile.Top == 0 && game.TurnNumber < 2)
                {
                    if (currentPlayer == 1)
                    {
                        game.PlaceFlat(2, tile);
                    }
                    else
                    {
                        game.PlaceFlat(1, tile);
                    }
                }
                // Generic case
            }


            else if (keyPressed == ConsoleKey.Escape)
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }

        public void ContextActions(int currentPlayer, Tile tile)
        {
            // Invalid Tile Selection
            if (tile.ControllingPlayer != currentPlayer && tile.ControllingPlayer != 0)
            {
                // Dont think I actually need to do much here. should just go back to the game's while loop via return to GetKey
            }
            // Initial Stone placement for each players' first turn
            else if (game.TurnNumber < 2){
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.F)
                {
                    tile.ControllingPlayer = ((game.TurnNumber % 2) + 2);
                    tile.Top = 1;
                    tile.TileState.Add($"{currentPlayer}");
                    game.gfx.DrawTile(tile);
                }
                else
                {
                    game.gfx.ClearContext();
                }
            }
        }
    }
}