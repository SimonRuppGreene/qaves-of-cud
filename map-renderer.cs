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
                    if (actor.position.y == y) {
                        lineToWrite[actor.position.x] = "@";
                    }
                }

                Console.WriteLine(String.Join(' ', lineToWrite));
            }
        }
    }
}
