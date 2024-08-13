using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public interface IPlayerMover {
        void Move(Vector2 input, Transform origin, float deltaTime);
    }
}

