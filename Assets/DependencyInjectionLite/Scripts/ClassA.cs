using UnityEngine;

namespace Sandbox.DependencyInjectionLite
{
    public class ClassA : MonoBehaviour {
        ServiceA serviceA;
        IProjectileSpawner projectileSpawner;

        [Inject]
        public void Init(ServiceA serviceA, IProjectileSpawner projectileSpawner) {
            this.serviceA = serviceA;
            this.projectileSpawner = projectileSpawner;
        }

        private void Update() {
            // On keypress 1, spawn projectile
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                projectileSpawner.Spawn();
            }
        }
    }
}
