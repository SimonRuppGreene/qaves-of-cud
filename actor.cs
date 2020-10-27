using System;

namespace roguelike {
    public class Actor {
        string name;
        
        int currentDepth;
        public Coordinate position {get; private set;}
        public IActorController controller;


        public string token {get; set;}

        public Actor (string _name, int _depth, Coordinate _position, IActorController _controller) {
            name = _name;
            currentDepth = _depth;
            position = _position;
            controller = _controller;
        }

        public void onTimestep (ConsoleKey key) {
            controller.onTimestep(key, this);
        }

        public void Move (Coordinate newPosition) {
            position = newPosition;
        }
    }
}