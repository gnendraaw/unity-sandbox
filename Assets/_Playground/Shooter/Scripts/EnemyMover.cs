using UnityEngine;

namespace Sandbox.Playground.Shooter {
    public class EnemyMover : MonoBehaviour {
        private float speed;

        public void SetSpeed(float speed) {
            this.speed = speed;
        }

        private void Update() {
            // Possible changes - Strategy Pattern for Movement
            transform.position += Time.deltaTime * speed * transform.up;
        }
    }
}

