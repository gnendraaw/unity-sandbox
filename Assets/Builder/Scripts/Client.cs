using UnityEngine;

namespace Sandbox.BuilderPattern
{
    public class Client : MonoBehaviour {
        [SerializeField] private CarType carType;

        private void Start() {
            MakeCar();
        }

        private void MakeCar() {
            var director = new Director();

            var carBuilder = new CarBuilder();
            ConstructCar(director, carBuilder);
            var car = carBuilder.GetResult();
            car.StartCar();

            var carManualBuilder = new CarManualBuilder();
            ConstructCar(director, carManualBuilder);
            var carManual = carManualBuilder.GetResult();
            carManual.PrintManual();
        }

        private void ConstructCar(Director director, IBuider builder) {
            if (carType == CarType.SportCar) {
                director.ConstructSportCar(builder);
            } else if (carType == CarType.SUV) {
                director.ConstructSUV(builder);
            } else {
                throw new System.Exception("Error! Unknown Car Type");
            }
        }
    }

    [System.Serializable]
    public enum CarType {
        SportCar,
        SUV
    }
}

