using UnityEngine;

namespace Ardell.DI.Sample {
    public class PlayerInstaller : MonoBehaviour, IDependencyInstaller {
        [SerializeField] private HeroWeaponComponent weaponComponent;
        [SerializeField] private MockHeroWeapon mockWeaponComponent;

        public void Install() {
            DIContainer.Instance.RegisterLazySingleton<IHeroWeaponComponent>(() => weaponComponent);
        }
    }
}
