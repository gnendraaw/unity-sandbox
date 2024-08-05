using System;
using UnityEngine;

namespace Sandbox.AbstractFactory
{
    [DefaultExecutionOrder(-999)]
    public class Bootstraper : MonoBehaviour {
        public FurnitureType furnitureType;
        public App app;

        private void Awake() {
            IFurnitureFactory factory = furnitureType switch {
                FurnitureType.Modern => new ModernFurnitureFactory(),
                FurnitureType.Classic => new ClassicFurnitureFactory(),
                _ => throw new AggregateException("Error! Unknown Furniture Type"),
            };

            app.Initialize(factory);
        }
    }

    [System.Serializable]
    public enum FurnitureType {
        Modern,
        Classic
    }
}