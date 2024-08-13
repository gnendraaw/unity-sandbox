using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public class PlayerWeapon : IPlayerWeapon {
        private readonly PlayerData playerData;
        private readonly IProjectileCreator projectileCreator;

        public PlayerWeapon(PlayerData playerData) {
            this.playerData = playerData;
            projectileCreator = new ProjectileCreator();
        }

        public void Fire(Transform firepoint) {
            Debug.Log("PlayerWeapon.Fire(Transform)");
            var projectile = projectileCreator.CreateProjectile(playerData.Projectile);
            projectile.transform.SetPositionAndRotation(firepoint.position, firepoint.rotation);
        }
    }
}

