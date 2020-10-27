using System;

namespace roguelike {
    class Program {

        static void Main(string[] args) {
            MapManager mapManager = new MapManager();
            MapRenderer renderer = new MapRenderer();

            Actor player = new Actor("Player", mapManager.currentDepth, new Coordinate(0, 0), new PlayerController());
            player.token = "@";

            mapManager.actors.Add(player);
            
            
            for (int i = 0; i < 5; i++) {
                
                int newX = MiscUtils.StaticRandom.Next(mapManager.map.xMax);
                int newY = MiscUtils.StaticRandom.Next(mapManager.map.yMax);
                Coordinate startPosition = new Coordinate(newX, newY);
                // what the fuck why does it not get the values when passing em
                startPosition.x = newX;
                startPosition.y = newY;
                Console.WriteLine($"start position: {mapManager.map.xMax} {startPosition.x},{startPosition.y}");
                
                Actor cow = new Actor("Cow", 0, startPosition, new AIController());
                cow.token = "m";

                mapManager.actors.Add(cow);
            }

            
            renderWelcome();
            
            ConsoleKeyInfo keyPress;
            while ((keyPress = Console.ReadKey()).Key != ConsoleKey.Q) {
                Console.Clear();

                if (keyPress.Key == ConsoleKey.D) {
                    mapManager.descend();
                }

                if (keyPress.Key == ConsoleKey.A) {
                    mapManager.ascend();
                }

                foreach (Actor actor in mapManager.actors) {
                    actor.onTimestep(keyPress.Key);
                }

                Console.WriteLine("\n");
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
