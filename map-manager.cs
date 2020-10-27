using System;
using System.Collections.Generic;
using System.Linq;

namespace roguelike {

    public class Coordinate {
        public int x {get; set;}
        public int y {get; set;}

        public Coordinate (int x, int y) {
            x = x;
            y = y;
        }

    }

    public class Map {
        public string[,] mapMatrix;

        public int xMax {get; private set;}
        public int yMax {get; private set;}

        public Map (int xMax, int yMax) {
            this.xMax = xMax;
            this.yMax = yMax;
            mapMatrix = new string[yMax, xMax];
        }

        public string[] getColumn (int colIndex) {
            return Enumerable.Range(0, mapMatrix.GetLength(0))
                .Select(x => mapMatrix[x, colIndex])
                .ToArray();
        }

        public string[] getRow (int rowIndex) {
            return Enumerable.Range(0, mapMatrix.GetLength(1))
                .Select(x => mapMatrix[rowIndex, x])
                .ToArray();
        }
    }

    public class MapManager {
        int xMax = 20;
        int yMax = 20;

        public int currentDepth = 0;

        MapGenerator mapGenerator;
        public Map map;

        List<Map> maps = new List<Map>();
        public HashSet<Actor> actors = new HashSet<Actor>();

        public MapManager () {
            mapGenerator = new MapGeneratorFlat();
            map = mapGenerator.GenerateMap(xMax, yMax);

            maps.Insert(currentDepth, map);
        }

        public void descend () {
            this.currentDepth += 1;

            if (maps.Count == currentDepth) {
                MapGenerator randMap = new MapGeneratorRandom();
                Map newMap = randMap.GenerateMap(xMax, yMax);

                maps.Insert(currentDepth, newMap);
            }

            
        }

        public void ascend () {
            if (currentDepth > 0) {
                currentDepth -= 1;
            }
        }

        public Map getCurrentMap () {
            return maps[currentDepth];
        }
    }
}

