using System;

namespace roguelike {
    class AIController : IActorController {

        public AIController() {
            
        }

        public void onTimestep (ConsoleKey key, Actor actor) {
            // 0-3 == move a direction
            // 4 == stay where you are
            int nextDirection = MiscUtils.StaticRandom.Next(0, 5);

            Coordinate nextPosition = new Coordinate(0, 0);
            nextPosition.x = actor.position.x;
            nextPosition.y = actor.position.y;

            // up
            if (nextDirection == 0) {
                nextPosition.y -= 1;
            }

            // right
            if (nextDirection == 1) {
                nextPosition.x += 1;
            }
            
            // down
            if (nextDirection == 2) {
                nextPosition.y += 1;
            }

            // left
            if (nextDirection == 3) {
                nextPosition.x -= 1;
            }

            actor.Move(nextPosition);
        }
    }
}