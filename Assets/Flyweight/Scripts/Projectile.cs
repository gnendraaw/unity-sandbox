using System.Collections;
using UnityEngine;

namespace Sandbox.Flyweight
{
    public class Projectile : MonoBehaviour {
        private ProjectileData data;
        public ProjectileData Data => data;
        private float Speed => data.Speed;
        private float LifeTime => data.LifeTime;

        public void SetProjectileData(ProjectileData data) {
            this.data = data;
        }

        public void Initialize() {
            StartCoroutine(DespawnAfterDelay());
        }

        private void Update() {
            Move();
        }

        private void Move() {
            transform.position += Time.deltaTime * Speed * transform.up;
        }

        private IEnumerator DespawnAfterDelay() {
            yield return new WaitForSeconds(LifeTime);
            ProjectileFactory.Instance.Release(this);
        }
    }
}

