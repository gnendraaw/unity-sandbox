using UnityEngine;

namespace Sandbox.Playground.Shooter {
    public class PlayerMover : IPlayerMover {
        private readonly float speed;

        public PlayerMover(float speed) {
            this.speed = speed;
        }

        public void Move(Vector2 input, Transform origin, float deltaTime) {
            Vector3 direction = new(input.x, input.y);
            origin.position += deltaTime * speed * direction;
        }
    }
}

