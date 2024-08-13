using System.Collections;
using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public class Projectile : MonoBehaviour {
        public ProjectileData data;
        private IProjectileMover mover;
        private IProjectileCreator creator;

        public void SetProjectileData(ProjectileData data) {
            this.data = data;
        }

        public void SetProjectileMover(IProjectileMover mover) {
            this.mover = mover;
        }

        public void SetCreator(IProjectileCreator creator) {
            this.creator = creator;
        }

        private void OnEnable() {
            StartCoroutine(DespawnAfterDelay());
        }

        private IEnumerator DespawnAfterDelay() {
            yield return new WaitForSeconds(data.LifeTime);
            // Despawn logic here...
            creator.Despawn(this);
        }

        private void Update() {
            mover.Move(transform, data.Speed, Time.deltaTime);
        }
    }
}

