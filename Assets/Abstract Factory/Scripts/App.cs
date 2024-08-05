using System;
using UnityEngine;

namespace Sandbox.AbstractFactory
{
    public class App : MonoBehaviour {
        [SerializeField] private FurnitureType furnitureType;

        private IFurnitureFactory factory;

        private void Awake() {
            factory = furnitureType switch {
                FurnitureType.Modern => new ModernFurnitureFactory(),
                FurnitureType.Classic => new ClassicFurnitureFactory(),
                _ => throw new AggregateException("Error! Unknown Furniture Type"),
            };
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

    [System.Serializable]
    public enum FurnitureType {
        Modern,
        Classic
    }
}