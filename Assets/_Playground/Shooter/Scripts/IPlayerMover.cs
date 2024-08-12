using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public interface IPlayerMover {
        void Move(Transform origin, float speed, float deltaTime);
    }
}

