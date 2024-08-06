using System.Collections;
using UnityEngine;

namespace Sandbox.Singleton
{
    public class Enemy : MonoBehaviour {
        private EnemyType type;
        public EnemyType Type => type;

        public void SetType(EnemyType type) {
            this.type = type;
        }

        public void StartDespawnCountdown() {
            StartCoroutine(DespawnAfterDelay());
        }

        private IEnumerator DespawnAfterDelay() {
            yield return new WaitForSeconds(type.Lifetime);
            EnemyCreator.GetInstance().Despawn(this);
        }

        private void Update() {
            transform.position += Time.deltaTime * type.Speed * transform.up;
        }
    }
}

