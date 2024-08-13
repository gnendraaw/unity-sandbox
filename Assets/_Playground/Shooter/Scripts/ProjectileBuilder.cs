using Extensions;
using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    public interface IProjectileBuilder {
        void Reset();
        void SetProjectileData(ProjectileData data);
        void SetMover(IProjectileMover mover);
    }

    public class ProjectileBuilder : IProjectileBuilder {
        Projectile product;

        public void Reset() {
            product = null;
        }

        public void SetProjectileData(ProjectileData data) {
            var instance = GameObject.Instantiate(data.Prefab);
            product = instance.GetOrAdd<Projectile>();
            product.SetProjectileData(data);
        }

        public void SetMover(IProjectileMover mover) {
            product.SetProjectileMover(mover);
        }

        public Projectile GetProduct() {
            var product = this.product;
            Reset();
            return product;
        }
    }

    public class ProjectileDirector {
        public void ConstructProjectile(IProjectileBuilder builder, ProjectileData data) {
            builder.SetProjectileData(data);
            builder.SetMover(new ProjectileMover());
        }
    }
}

