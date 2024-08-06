using System.Collections;
using UnityEngine;

namespace Sandbox.FactoryMethod
{
    public class Enemy : MonoBehaviour, IEnemy {
        private GameObject prefab;
        private float speed;

        public void SetPrefab(GameObject prefab) {
            this.prefab = prefab;
        }

        public void SetSpeed(float speed) {
            this.speed = speed;
        }

        public void SetPosition(Vector3 position) {
            transform.position = position;
        }

        public void SetRotation(Quaternion rotation) {
            transform.rotation = rotation;
        }

        private void OnEnable() {
            Debug.Log($"Enemy.OnEnable");

            StartCoroutine(DespawnAfterDelay());
        }

        private IEnumerator DespawnAfterDelay() {
            Debug.Log($"Enemy.DespawnAfterDelay");

            yield return new WaitForSeconds(1);
            FindObjectOfType<Creator>().DespawnEnemy(this);
        }

        private void Update() {
            Move();
        }

        private void Move() {
            transform.position += speed * Time.deltaTime * transform.up;
        }
    }
}

