using UnityEngine;

namespace Ardell.DI.Sample {
    public interface IHeroWeaponComponent {
        void Fire();
    }

    public class HeroWeaponComponent : MonoBehaviour, IHeroWeaponComponent {
        [SerializeField] private Transform _firepoint;
        [SerializeField] private HeroWeaponSettings _settings;

        [Inject] IAudioSystem audioSystem;

        public void Fire() {
            Debug.Log("HeroWeaponComponent.Fire");
            audioSystem.Play(_settings.FireAudio, _settings.FireAudioVolume);
        }
    }
}
