using System;

namespace roguelike {
    interface MapGenerator {
        Map GenerateMap(int xMax, int yMax);
    }
}