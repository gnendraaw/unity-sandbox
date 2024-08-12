using UnityEngine;
using UnityEngine.UI;

namespace Sandbox.BridgePattern
{
    public class TimerView : MonoBehaviour {
        [SerializeField] private Button increaseTimerButton;
        [SerializeField] private Button decreaseTimerButton;
        [SerializeField] private Button toggleTimerButton;

        private ITimerImpl timerImpl;

        private void Awake() {
            increaseTimerButton.onClick.AddListener(IncreaseTimer);
            decreaseTimerButton.onClick.AddListener(DecreaseTimer);
            toggleTimerButton.onClick.AddListener(ToggleTimer);
        }

        public void IncreaseTimer() {
            timerImpl.SetTimer(timerImpl.GetTimer() + 10);
        }

        public void DecreaseTimer() {
            timerImpl.SetTimer(timerImpl.GetTimer() - 10);
        }

        public void ToggleTimer() {
            if (!timerImpl.IsRunning)
                timerImpl.Start();
            else
                timerImpl.Pause();
        }

        public void ChangeImplementation(ITimerImpl timerImpl) {
            this.timerImpl = timerImpl;
        }

        public void ResetTimer() {
            timerImpl.Reset();
        }
    }
}