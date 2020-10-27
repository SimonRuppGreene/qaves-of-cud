using System;

namespace roguelike {
    class Program {
        static void Main(string[] args) {
            MapManager mapManager = new MapManager();
            MapRenderer renderer = new MapRenderer();

            Actor player = new Actor("Player", mapManager.currentDepth, new Coordinate(0, 0));
            mapManager.actors.Add(player);
            
            PlayerController controller = new PlayerController(player);
            
            renderWelcome();
            
            ConsoleKeyInfo keyPress;
            while ((keyPress = Console.ReadKey()).Key != ConsoleKey.Q) {
                if (keyPress.Key == ConsoleKey.D) {
                    mapManager.descend();
                }

                if (keyPress.Key == ConsoleKey.A) {
                    mapManager.ascend();
                }

                controller.onKeyPress(keyPress.Key);

                renderer.Render(mapManager.getCurrentMap(), mapManager.actors);
                renderPrompt(mapManager.currentDepth);
            }
        }


        static void renderWelcome () {
            Console.WriteLine("#########################################");
            Console.WriteLine("\n\n");
            Console.WriteLine("\t Welcome to the dungeon.\t");
            Console.WriteLine("\tPress any key to continue\t");
            Console.WriteLine("\n\n");
            Console.WriteLine("#########################################");
        }

        static void renderPrompt (int currentDepth) {
            Console.WriteLine("\n\n");
            Console.WriteLine($"Current depth: {currentDepth}");
            Console.WriteLine("d)escend");
            Console.WriteLine("a)scend");
            Console.Write("> ");
        }
    }
}
