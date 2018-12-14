using System;

namespace Tak
{
    public class GFX
    {
        public Game game {get; set;}
        public GFX(Game game)
        {
            this.game = game;
            Initialize();
        }
        
        public void Initialize()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetBufferSize(172, 52);
            Console.SetWindowSize(170, 50);
            Console.SetWindowPosition(1, 1);
            Console.SetCursorPosition(1, 1);
        }

        public void DrawTile(Tile tile)
        {
            // Check Cursor status
            if( tile.HasCursor == true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = tile.TileColor;
            }
            Console.CursorLeft = 5+15*tile.TileX;
            Console.CursorTop = 6+7*tile.TileY;

            // paint Tile background
            for(int i = 0; i < 7; i++)
            {
                Console.CursorLeft = 5+15*tile.TileX;
                Console.CursorTop = 6+7*tile.TileY + i;
                Console.Write("               ");
            }
            
            // check tile.TileState
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorLeft = 5+15*tile.TileX;
            Console.CursorTop = 12+7*tile.TileY;
            if(tile.TileState.Count > 0)
            {
                for(int i = 0; i < tile.TileState.Count; i++){
                    Console.Write(tile.TileState[i]);
                }
            }
            
            // Draw Flat Stones
            if(tile.Top == 1)
            {
                if(tile.ControllingPlayer == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;

                }
                Console.CursorLeft = 8+15*tile.TileX;
                Console.CursorTop = 7+7*tile.TileY;
                for(int i = 0; i < 4; i++)
                {
                    Console.CursorLeft = 8+15*tile.TileX;
                    Console.CursorTop = 7+7*tile.TileY + i;
                    Console.Write("        ");
                }
                Console.ResetColor();
            }
            Console.ResetColor();
        }

        public void DrawCursor(Tile tile)
        {
            Console.BackgroundColor = tile.TileColor;
            Console.CursorLeft = 5+15*tile.TileX;
            Console.CursorTop = 6+7*tile.TileY;
        }

        public void DrawBoard()
        {
            foreach(Tile tile in game.board.tiles)
            {
                DrawTile(tile);
            }
        }

        public void UpdateInventories()
        {
            Console.SetCursorPosition( 14, 2);
            Console.Write($"---------------------- Player {(game.TurnNumber % 2) + 1}'s Turn -------------------");
            if(game.TurnNumber < 2)
            {
                Console.SetCursorPosition( 14, 4);
                Console.Write("Each player during the first round places an opponent's Tile!");
            }
            Console.SetCursorPosition( 85, 4);
            Console.Write("           Capstone     Stones");
            Console.SetCursorPosition( 85, 7);
            Console.Write($"Player 1:     {game.P1.CapStone}           {game.P1.Stones}");
            Console.SetCursorPosition( 85, 10);
            Console.Write($"Player 2:     {game.P2.CapStone}           {game.P2.Stones}");
        }

        public void BuildContextMenu(int player, Tile tile)
        {
            Console.SetCursorPosition(85, 15);
            // Invalid tile selection
            if (player != tile.ControllingPlayer && tile.ControllingPlayer != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tile Currently Controlled By Opponent!");
                Console.ResetColor();
            }
            // First Round tile selection
            else if (game.TurnNumber < 2)
            {
                Console.Write("Press 'f' to place opponent wall piece.");
                Console.SetCursorPosition(85, 17);
                Console.Write("Press 'q' to select another tile.");
            }
            // Valid Tile selection after round 1.
            // Build a menu of options.
            else
            {

            }
        }

        public void ClearContext()
        {
            Console.SetCursorPosition(85, 15);
            Console.Write("                                                     ");
            Console.SetCursorPosition(85, 17);
            Console.Write("                                                     ");
            Console.SetCursorPosition(85, 19);
            Console.Write("                                                     ");
            Console.SetCursorPosition(85, 21);
            Console.Write("                                                     ");
        }

        public void MainMenu(){

        }
    }
}