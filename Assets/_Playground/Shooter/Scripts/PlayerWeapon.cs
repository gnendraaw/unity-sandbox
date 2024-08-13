using UnityEngine;

namespace Sandbox.Playground.Shooter {
    public class PlayerWeapon : IPlayerWeapon {
        public void Fire(Transform firepoint) {
            Debug.Log("PlayerWeapon.Fire(Transform)");
        }
    }
}

