using System;

namespace roguelike
{
    public interface IActorController {
        void onTimestep (ConsoleKey key, Actor actor);
    }
}