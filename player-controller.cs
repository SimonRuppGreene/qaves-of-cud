using System;

namespace roguelike {
    class PlayerController {
        Actor playerActor;

        public PlayerController(Actor actor) {
            playerActor = actor;
        }

        public void onKeyPress (ConsoleKey key) {
            Coordinate newCoordinate = playerActor.position;

            if (key == ConsoleKey.UpArrow) {
                newCoordinate.y -= 1;
            }

            if (key == ConsoleKey.RightArrow) {
                newCoordinate.x += 1;
            }

            if (key == ConsoleKey.DownArrow) {
                newCoordinate.y += 1;
            }

            if (key == ConsoleKey.LeftArrow) {
                newCoordinate.x -= 1;
            }
            
            Console.WriteLine($"new coord: {newCoordinate.x} {newCoordinate.y}");
            playerActor.Move(newCoordinate);
        }
    }
}
