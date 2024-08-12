namespace Sandbox.BridgePattern
{
    public interface ITimerImpl {
        bool IsRunning { get; }
        void SetTimer(int value);
        int GetTimer();
        void Start();
        void Pause();
        void Reset();
    }
}

