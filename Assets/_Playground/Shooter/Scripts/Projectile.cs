using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public class Projectile : MonoBehaviour {
        private ProjectileData data;
        private IProjectileMover mover;

        public void SetProjectileData(ProjectileData data) {
            this.data = data;
        }

        public void SetProjectileMover(IProjectileMover mover) {
            this.mover = mover;
        }

        private void Update() {
            mover.Move(transform, data.Speed, Time.deltaTime);
        }
    }
}

