namespace Sandbox.BuilderPattern
{
    public interface IBuider {
        void Reset();
        void SetEngine(IEngine engine);
        void SetSeat(int seatCount);
    }
}

