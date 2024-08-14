using System.Collections;
using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public class Projectile : MonoBehaviour {
        public ProjectileData data;
        private IProjectileMover mover;

        public void SetProjectileData(ProjectileData data) {
            this.data = data;
        }

        public void SetProjectileMover(IProjectileMover mover) {
            this.mover = mover;
        }

        private void OnEnable() {
            StartCoroutine(DespawnAfterDelay());
        }

        private IEnumerator DespawnAfterDelay() {
            yield return new WaitForSeconds(data.LifeTime);
            ProjectileCreator.Instance.Despawn(this);
        }

        private void Update() {
            mover.Move(transform, data.Speed, Time.deltaTime);
        }
    }
}

