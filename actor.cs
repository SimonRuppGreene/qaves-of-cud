using System;

namespace roguelike {
    public class Actor {
        string name;

        int currentDepth;
        public Coordinate position {get; private set;}

        public Actor (string _name, int _depth, Coordinate _position) {
            name = _name;
            currentDepth = _depth;
            position = _position;
        }


        public void Move (Coordinate newPosition) {
            position = newPosition;
        }
    }
}