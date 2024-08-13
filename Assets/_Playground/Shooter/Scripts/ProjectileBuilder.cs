using Extensions;
using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public class ProjectileBuilder : IProjectileBuilder {
        Projectile product;

        public void Reset() {
            product = null;
        }

        public void SetProjectileData(ProjectileData data) {
            var instance = GameObject.Instantiate(data.Prefab);
            instance.SetActive(false);
            product = instance.GetOrAdd<Projectile>();
            product.SetProjectileData(data);
        }

        public void SetMover(IProjectileMover mover) {
            product.SetProjectileMover(mover);
        }

        public void SetCreator(IProjectileCreator creator) {
            product.SetCreator(creator);
        }

        public Projectile GetProduct() {
            var product = this.product;
            Reset();
            return product;
        }
    }

    public class ProjectileDirector {
        public void ConstructProjectile(IProjectileBuilder builder, ProjectileData data, IProjectileCreator creator) {
            builder.SetProjectileData(data);
            builder.SetMover(new ProjectileMover());
            builder.SetCreator(creator);
        }
    }
}

