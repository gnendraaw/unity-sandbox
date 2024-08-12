using UnityEngine;
using TMPro;

namespace Sandbox.BridgePattern
{
    public class TimerImpl : MonoBehaviour, ITimerImpl {
        [SerializeField] private TextMeshProUGUI timerText;

        private const int MINUTE_IN_SECONDS = 60;
        private const int MIN_TIMER_SECONDS = 0;
        private const int MAX_TIMER_SECONDS = 300;

        private int timer;
        private float progress;
        private bool isRunning;
        public bool IsRunning => isRunning;

        private void Awake() {
            timer = MIN_TIMER_SECONDS;
            progress = MIN_TIMER_SECONDS;
            isRunning = false;
        }

        private void Update() {
            if (isRunning) {
                Tick();
            }
        }

        private void Tick() {
            progress -= Time.deltaTime;

            // Update timer text
            timerText.text = GetMinutes(Mathf.CeilToInt(progress)) + ":" + GetSeconds(Mathf.CeilToInt(progress));

            if (progress <= MIN_TIMER_SECONDS) {
                isRunning = false;
            }
        }

        private int GetMinutes(int seconds) {
            return seconds / MINUTE_IN_SECONDS;
        }

        private int GetSeconds(int seconds) {
            return seconds % MINUTE_IN_SECONDS;
        }

        public void SetTimer(int value) {
            Debug.Log($"TimerImpl.SetTimer(int)");
            if (value <= MIN_TIMER_SECONDS || value > MAX_TIMER_SECONDS) return;

            timer = value;
            progress = timer;
            timerText.text = GetMinutes(Mathf.CeilToInt(progress)) + ":" + GetSeconds(Mathf.CeilToInt(progress));
        }

        public int GetTimer() {
            return timer;
        }

        public void Start() {
            Debug.Log($"TimerImpl.Start");
            isRunning = true;
        }

        public void Pause() {
            Debug.Log($"TimerImpl.Pause");
            isRunning = false;
        }

        public void Reset() {
            Debug.Log($"TimerImpl.Reset");
            timer = MIN_TIMER_SECONDS;
            progress = MIN_TIMER_SECONDS;
        }
    }
}

