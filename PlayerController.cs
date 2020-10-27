using System;

namespace roguelike {
    class PlayerController : IActorController {
        

        public PlayerController() {
            
        }

        public void onTimestep(ConsoleKey key, Actor actor) {
            this.onKeyPress(key, actor);
        }

        public void onKeyPress (ConsoleKey key, Actor playerActor) {
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
            
            playerActor.Move(newCoordinate);
        }
    }
}
