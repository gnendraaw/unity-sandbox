using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Sandbox.Playground.Shooter
{
    public interface IProjectileCreator {
        Projectile CreateProjectile(ProjectileData data);
        void Despawn(Projectile projectile);
    }

    public class ProjectileCreator : IProjectileCreator {
        private readonly ProjectileBuilder builder;
        private readonly ProjectileDirector director;

        public ProjectileCreator() {
            builder = new ProjectileBuilder();
            director = new ProjectileDirector();
        }

        public Projectile CreateProjectile(ProjectileData data) => GetPoolFor(data).Get();
        public void Despawn(Projectile projectile) => GetPoolFor(projectile.data).Release(projectile);

        private readonly Dictionary<ProjectileType, IObjectPool<Projectile>> pools = new();
        private readonly bool collectionCheck = true;
        private readonly int defaultCapacity = 10;
        private readonly int maxSize = 100;

        private IObjectPool<Projectile> GetPoolFor(ProjectileData data) {
            if (pools.TryGetValue(data.Type, out var pool))
                return pool;
            
            pool = new ObjectPool<Projectile>(
                () => OnCreate(data),
                OnGet,
                OnRelease,
                OnDestroy,
                collectionCheck,
                defaultCapacity,
                maxSize
            );

            pools.Add(data.Type, pool);
            return pool;
        }

        private Projectile OnCreate(ProjectileData data) {
            director.ConstructProjectile(builder, data, this);
            return builder.GetProduct();
        }

        private void OnGet(Projectile projectile) {
            projectile.gameObject.SetActive(true);
        }

        private void OnRelease(Projectile projectile) {
            projectile.gameObject.SetActive(false);
        }

        private void OnDestroy(Projectile projectile) {
            GameObject.Destroy(projectile.gameObject);
        }
    }
}

