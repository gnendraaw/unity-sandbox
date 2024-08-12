using UnityEngine;
using UnityEngine.UI;

namespace Sandbox.Flyweight {
    public class ProjectileSpawner : MonoBehaviour {
        [SerializeField] private Button spawnProjectileButton;
        [SerializeField] private Transform spawnPoint;

        private void Awake() => spawnProjectileButton.onClick.AddListener(SpawnRandomProjectile);
        private void SpawnRandomProjectile() => SpawnProjectile(ProjectileType.Circle);
        private void SpawnProjectile(ProjectileType type) {
            var projectile = ProjectileFactory.Instance.Get(type);
            projectile.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        }
    }
}

