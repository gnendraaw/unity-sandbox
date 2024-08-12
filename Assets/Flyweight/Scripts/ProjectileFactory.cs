using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

namespace Sandbox.Flyweight {
    public class ProjectileFactory : MonoBehaviour {
        public static ProjectileFactory Instance { get; private set; }

        [SerializeField] private ProjectileData[] projectiles;

        private readonly ProjectileBuilder builder = new();

        private readonly Dictionary<ProjectileType, IObjectPool<Projectile>> pools = new();
        private readonly bool collectionCheck = true;
        private readonly int defaultCapacity = 10;
        private readonly int maxSize = 100;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }

        public Projectile Get(ProjectileType type) => GetPoolFor(type).Get();
        public void Release(Projectile projectile) => GetPoolFor(projectile.Data.Type).Release(projectile);

        private IObjectPool<Projectile> GetPoolFor(ProjectileType type) {
            if (pools.TryGetValue(type, out var pool))
                return pool;
            
            pool = new ObjectPool<Projectile>(
                () => OnCreate(type),
                OnGet,
                OnRelease,
                Destroy,
                collectionCheck,
                defaultCapacity,
                maxSize
            );

            pools.Add(type, pool);
            return pool;
        }

        private void OnRelease(Projectile projectile) {
            projectile.gameObject.SetActive(false);
        }
        private void OnGet(Projectile projectile) {
            projectile.gameObject.SetActive(true);
            projectile.Initialize();
        }

        private Projectile OnCreate(ProjectileType type) {
            var data = projectiles.FirstOrDefault(x => x.Type == type);

            builder.Reset();
            builder.SetProjectileData(data);

            return builder.GetProduct();
        }
    }
}

