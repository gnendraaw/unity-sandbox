using UnityEngine;

namespace Ardell.DI.Sample {
    [CreateAssetMenu(fileName = "HeroWeaponSettings", menuName = "Game Settings / Hero / Weapon Settings")]
    public class HeroWeaponSettings : ScriptableObject {
        public float ShootingInterval;
        public AudioClip FireAudio;
        public float FireAudioVolume;
    }
}
