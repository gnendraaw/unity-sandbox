using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public class PlayerWeapon : IPlayerWeapon {
        private readonly PlayerData playerData;

        public PlayerWeapon(PlayerData playerData) {
            this.playerData = playerData;
        }

        public void Fire(Transform firepoint) {
            Debug.Log("PlayerWeapon.Fire(Transform)");
            var projectile = ProjectileCreator.Instance.CreateProjectile(playerData.Projectile);
            projectile.transform.SetPositionAndRotation(firepoint.position, firepoint.rotation);
        }
    }
}

