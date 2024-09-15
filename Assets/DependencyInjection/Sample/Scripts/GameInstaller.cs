using UnityEngine;

namespace Ardell.DI.Sample {
    [DefaultExecutionOrder(-999)]
    public class GameInstaller : MonoBehaviour {
        private static GameInstaller instance;
        public static GameInstaller Instance {
            get {
                if (instance == null) {
                    instance = FindAnyObjectByType<GameInstaller>();
                    if (instance == null) {
                        var go = new GameObject($"Auto-generated {typeof(GameInstaller).Name}");
                        instance = go.AddComponent<GameInstaller>();
                    }
                }
                return instance;
            }
        }

        private void Awake() {
            InitializeSingleton();

            var hero = FindAnyObjectByType<Hero>();
            var audioSystem = FindAnyObjectByType<AudioSystem>();

            DIContainer.Instance.RegisterLazySingleton<IAudioSystem>(() => audioSystem);
            hero.AudioSystem = DIContainer.Instance.Resolve<IAudioSystem>();
        }

        private void InitializeSingleton() {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(gameObject);
            }
        }
    }
}
