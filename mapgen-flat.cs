using System;

namespace roguelike {
    class MapGeneratorFlat : MapGenerator {
        public Map GenerateMap(int xMax, int yMax) {
            Map map = new Map(xMax, yMax);

            for (int y = 0; y < yMax; y++) {
                for (int x = 0; x < xMax; x++) {
                    map.mapMatrix[y, x] = ".";
                }
            }

            return map;
        }
    }
}
