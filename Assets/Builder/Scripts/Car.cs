namespace Sandbox.BuilderPattern
{
    public class Car {
        private int seatCount;
        private IEngine engine;

        public void SetSeatCount(int seatCount) {
            this.seatCount = seatCount;
        }

        public void SetEngine(IEngine engine) {
            this.engine = engine;
        }

        public void StartCar() {
            UnityEngine.Debug.Log($"Car.StartCar");
            engine.StartEngine();
        }
    }
}