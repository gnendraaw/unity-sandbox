using UnityEngine;

namespace Ardell.DI {
    public interface IDependencyInstaller {
        void Install();
    }

    public class TestDependencyInstaller : MonoBehaviour, IDependencyInstaller {
        public void Install() {

        }
    }
}
