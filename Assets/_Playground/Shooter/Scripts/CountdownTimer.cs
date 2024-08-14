namespace Utils
{
    public class CountdownTimer {
        private float timer;
        private float progress;

        public CountdownTimer(float timer = 0f) {
            this.timer = timer;
            progress = 0f;
        }

        public bool IsRunning() {
            return progress < timer;
        }

        public void Reset() {
            progress = 0f;
        }

        public void Reset(float newTimer) {
            timer = newTimer;
            progress = 0f;
        }

        public void Tick(float deltaTime)  {
            if (IsRunning())
                progress += deltaTime;
        }
    }
}

