using Extensions;
using UnityEngine;

namespace Sandbox.Playground.Shooter {
    public class EnemyBuilder {
        EnemyController product;

        public void Reset() {
            product = null;
        }

        public void SetEnemyData(EnemyData data) {
            var instance = GameObject.Instantiate(data.Prefab);
            instance.SetActive(false);

            product = instance.GetOrAdd<EnemyController>();
            product.SetEnemyData(data);
        }

        // public void SetMover(mover: interface);

        public EnemyController GetProduct() {
            var product = this.product;
            product.gameObject.GetOrAdd<EnemyMover>();
            product.gameObject.SetActive(true);

            Reset();

            return product;
        }
    }
}

