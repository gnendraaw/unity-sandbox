using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public class PlayerWeapon : IPlayerWeapon {
        private readonly ProjectileBuilder projectileBuilder;
        private readonly ProjectileDirector ProjectileDirector;
        private readonly PlayerData playerData;

        public PlayerWeapon(PlayerData playerData) {
            this.playerData = playerData;
            projectileBuilder = new ProjectileBuilder();
            ProjectileDirector = new ProjectileDirector();
        }

        public void Fire(Transform firepoint) {
            Debug.Log("PlayerWeapon.Fire(Transform)");
            ProjectileDirector.ConstructProjectile(projectileBuilder, playerData.Projectile);
            var projectile = projectileBuilder.GetProduct();
            projectile.transform.SetPositionAndRotation(firepoint.position, firepoint.rotation);
        }
    }
}

