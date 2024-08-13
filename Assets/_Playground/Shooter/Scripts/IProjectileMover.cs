using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public interface IProjectileMover {
        void Move(Transform origin, float speed, float deltaTime);
    }
}

