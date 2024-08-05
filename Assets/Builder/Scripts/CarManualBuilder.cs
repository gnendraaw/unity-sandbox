namespace Sandbox.BuilderPattern
{
    public class CarManualBuilder : IBuider {
        private CarManual result;

        public CarManualBuilder() {
            Reset();
        }

        public void Reset() {
            result = new CarManual();
        }

        public void SetEngine(IEngine engine) {
            result.SetEngine(engine);
        }

        public void SetSeat(int seatCount) {
            result.SetSeatCount(seatCount);
        }

        public CarManual GetResult() {
            var result = this.result;
            Reset();
            return result;
        }
    }
}

