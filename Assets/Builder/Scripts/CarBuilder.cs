namespace Sandbox.BuilderPattern
{
    public class CarBuilder : IBuider {
        private Car result;

        public CarBuilder() {
            Reset();
        }

        public void Reset() {
            result = new Car();
        }

        public void SetEngine(IEngine engine) {
            result.SetEngine(engine);
        }

        public void SetSeat(int seatCount) {
            result.SetSeatCount(seatCount);
        }

        public Car GetResult() { 
            var result = this.result;

            Reset();

            return result;
        }
    }
}

