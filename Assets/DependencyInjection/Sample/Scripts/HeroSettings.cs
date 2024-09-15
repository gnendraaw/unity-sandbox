using System;
using UnityEngine;

namespace Ardell.DI.Sample {
    [CreateAssetMenu(fileName = "HeroSettings", menuName = "Game Settings / Hero Settings")]
    public class HeroSettings : ScriptableObject {
        public AttackSettings attackSettings;

        [Serializable]
        public class AttackSettings {
            public AudioClip attackAudio;
            public float attackVolume;
        }
    }
}
