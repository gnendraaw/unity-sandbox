using UnityEngine;

namespace Sandbox.BridgePattern {
    [DefaultExecutionOrder(-999)]
    public class Client : MonoBehaviour {
        [SerializeField] private TimerView timerView;
        [SerializeField] private TimerImpl timerImpl;

        private void Awake() {
            timerView.ChangeImplementation(timerImpl);
        }
    }
}