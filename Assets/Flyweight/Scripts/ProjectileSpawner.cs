using UnityEngine;
using UnityEngine.UI;

namespace Sandbox.Flyweight {
    // Possible Optimization - Object Pool, Command Pattern, Projectile Builder
    public class ProjectileSpawner : MonoBehaviour {
        [SerializeField] private ProjectileData[] projectiles;
        [SerializeField] private Button spawnProjectileButton;
        [SerializeField] private Transform spawnPoint;

        private ProjectileBuilder builder;

        // Factory Method
        public Projectile CreateProjectile() {
            // Retrieve instance from pool or return a new one if there's none
            return null;
        }

        private void Awake() {
            builder = new ProjectileBuilder();
            spawnProjectileButton.onClick.AddListener(SpawnRandomProjectile);
        }

        private void SpawnRandomProjectile() {
            SpawnProjectile(projectiles[Random.Range(0, projectiles.Length)]);
        }

        private void SpawnProjectile(ProjectileData data) {
            builder.Reset();
            builder.SetProjectileData(data);
            var projectile = builder.GetProduct();
            projectile.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        }
    }
}

