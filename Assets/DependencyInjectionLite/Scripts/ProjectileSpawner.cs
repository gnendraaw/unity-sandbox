using UnityEngine;

namespace Sandbox.DependencyInjectionLite {
    public interface IProjectileSpawner {
        void Spawn();
    }

    public class ProjectileSpawner : MonoBehaviour, IDependencyProvider, IProjectileSpawner {
        [Provide]
        IProjectileSpawner Provide() {
            return this;
        }

        public void Spawn() {
            Debug.Log($"ProjectileSpawner.Spawn");
        }
    }
}
