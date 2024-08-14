using UnityEngine;

namespace Sandbox.Playground.Shooter {
    public class EnemyController : MonoBehaviour {
        private EnemyData data;
        private EnemyMover mover;

        private void Awake() {
            Setup();
        }

        private void Setup() {
            mover = GetComponent<EnemyMover>();
        }

        public void SetEnemyData(EnemyData data) {
            this.data = data;
        }

        private void Update() {
            mover.SetSpeed(data.Speed);
        }
    }
}

