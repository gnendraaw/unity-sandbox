namespace Sandbox.BuilderPattern
{
    public class CarManual {
        private int seatCount;
        private IEngine engine;

        public void SetSeatCount(int seatCount) {
            this.seatCount = seatCount;
        }

        public void SetEngine(IEngine engine) {
            this.engine = engine;
        }

        public void PrintManual() {
            UnityEngine.Debug.Log($"CarManual.PrintManual");
            UnityEngine.Debug.Log($"This car has {seatCount} seat(s)");
            UnityEngine.Debug.Log($"This car has {engine.GetType()} engine");
        }
    }
}

