using UnityEngine;

namespace Ardell.DI.Sample {
    public class GameInstaller : MonoBehaviour, IDependencyInstaller {
        [SerializeField] private AudioSystem audioSystem;

        public void Install() {
            DIContainer.Instance.RegisterLazySingleton<IAudioSystem>(() => audioSystem);
        }
    }
}
