using UnityEngine;

namespace Ardell.DI.Sample {
    public interface IAudioSystem {
        void Play(AudioClip clip, float volume = 1f);
    }

    public class AudioSystem : MonoBehaviour, IAudioSystem {
        private AudioSource audioSource;

        private void Awake() {
            audioSource = Camera.main.GetComponent<AudioSource>();
        }

        public void Play(AudioClip clip, float volume = 1f) {
            audioSource.PlayOneShot(clip, volume);
            Debug.Log($"Audio {clip.name} played with volume: {volume}");
        }
    }
}
