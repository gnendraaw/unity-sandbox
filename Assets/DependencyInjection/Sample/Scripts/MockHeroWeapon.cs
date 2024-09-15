using UnityEngine;

namespace Ardell.DI.Sample
{
    public class MockHeroWeapon : MonoBehaviour, IHeroWeaponComponent {
        public void Fire() {
            Debug.Log($"MockHeroWeapon.Fire");
        }
    }
}
