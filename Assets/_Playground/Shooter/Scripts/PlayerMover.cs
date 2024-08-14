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

        public void LookAt(Transform origin, Vector3 targetWorldPosition) {
            Vector3 direction = targetWorldPosition - origin.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            origin.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}

