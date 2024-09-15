using UnityEngine;

namespace Ardell.DI.Sample {
    public class Hero : MonoBehaviour {
        [SerializeField] HeroSettings settings;

        IAudioSystem audioSystem;
        public IAudioSystem AudioSystem { 
            get => audioSystem;
            set {
                audioSystem = value;
            }
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                PerformAttack();
            }
        }

        private void PerformAttack() {
            audioSystem.Play(settings.attackSettings.attackAudio, settings.attackSettings.attackVolume);
        }
    }
}
