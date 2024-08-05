using UnityEngine;

namespace Sandbox.AbstractFactory
{
    public class App : MonoBehaviour {
        private IFurnitureFactory factory;

        public void Initialize(IFurnitureFactory factory) {
            this.factory = factory;
        }

        private void Start() {
            var chair = factory.CreateChair();
            var table = factory.CreateTable();
            var radio = factory.CreateRadio();

            chair.SitOn();
            table.PutStuff();
            radio.TurnOn();
            radio.TurnOff();
        }
    }
}