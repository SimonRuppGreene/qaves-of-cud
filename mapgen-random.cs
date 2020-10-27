using System;

namespace roguelike {
    class MapGeneratorRandom : MapGenerator {
        public Map GenerateMap(int xMax, int yMax) {
            Map map = new Map(xMax, yMax);
            Random rand = new Random();

            for (int y = 0; y < yMax; y++) {
                for (int x = 0; x < xMax; x++) {
                    map.mapMatrix[y, x] = rand.Next(0, 3) == 0 ? "#" : ".";
                }
            }

            return map;
        }
    }
}
