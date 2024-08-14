using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

namespace Sandbox.Playground.Shooter {
    public class ProjectilePool {
        private readonly ProjectileBuilder builder;
        private readonly ProjectileDirector director;

        public ProjectilePool(ProjectileBuilder builder, ProjectileDirector director) {
            this.builder = builder;
            this.director = director;
        }

        public Projectile Get(ProjectileData data) => GetPoolFor(data).Get();
        public void Release(Projectile projectile) => GetPoolFor(projectile.data).Release(projectile);

        #region Pool
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
            director.ConstructProjectile(builder, data);
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
        #endregion
    }
}


