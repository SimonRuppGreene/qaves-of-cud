using System;
using System.Collections.Generic;

namespace roguelike {
    class MapRenderer {
        public void Render (Map map, HashSet<Actor> actors) {
            for (int y = 0; y < map.yMax; y++) {
                string[] lineToWrite = new string[map.xMax];
                
                for (int x = 0; x < map.xMax; x++) {
                    lineToWrite[x] = map.mapMatrix[y, x];
                }

                foreach (Actor actor in actors) {
                    if (actor.position.y == y && isInBounds(map, actor.position)) {
                        lineToWrite[actor.position.x] = actor.token;
                    }
                }

                Console.WriteLine(String.Join(' ', lineToWrite));
            }

            Console.WriteLine("\n");
        }

        bool isInBounds (Map map, Coordinate coordinate) {
            return coordinate.x >= 0 && coordinate.x < map.xMax 
                && coordinate.y >= 0 && coordinate.y < map.yMax;
        }
    }
}
