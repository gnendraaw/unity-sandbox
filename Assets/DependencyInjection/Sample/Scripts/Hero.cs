using UnityEngine;

namespace Ardell.DI.Sample {
    public class Hero : MonoBehaviour {
        [SerializeField] HeroSettings settings;

        IHeroWeaponComponent weapon;
        IAudioSystem audioSystem;

        [Inject]
        public void Construct(IHeroWeaponComponent weapon) {
            this.weapon = weapon;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                PerformAttack();
            }
        }

        private void PerformAttack() => weapon.Fire();
    }
}
