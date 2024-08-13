using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public class ProjectileMover : IProjectileMover {
        public void Move(Transform origin, float speed, float deltaTime) {
            origin.position += deltaTime * speed * origin.up;
        }
    }
}

