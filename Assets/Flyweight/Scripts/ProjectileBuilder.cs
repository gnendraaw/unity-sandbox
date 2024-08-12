using UnityEngine;

namespace Sandbox.Flyweight {
    public class ProjectileBuilder : IProjectileBuilder {
        Projectile product;

        public void Reset() {
            product = null;
        }

        public void SetProjectileData(ProjectileData projectileData) {
            var instance = GameObject.Instantiate(projectileData.Prefab);
            // Update getting component logic with custom GameObject GetOrAdd extension later
            product = instance.GetComponent<Projectile>() ?? instance.AddComponent<Projectile>(); 
            product.SetProjectileData(projectileData);
        }

        public Projectile GetProduct() {
            var product = this.product;
            Reset();
            product.Initialize();
            return product;
        }
    }
}

