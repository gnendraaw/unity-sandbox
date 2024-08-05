namespace Sandbox.BuilderPattern
{
    public class Director {
        private IBuider builder;

        public void SetBuilder(IBuider builder) {
            this.builder = builder;
        }

        public void ConstructSportCar(IBuider builder) {
            builder.SetEngine(new SportEngine());
            builder.SetSeat(2);
        }

        public void ConstructSUV(IBuider builder) {
            builder.SetEngine(new SUVEngine());
            builder.SetSeat(4);
        }
    }
}

