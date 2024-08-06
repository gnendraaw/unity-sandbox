using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

namespace Sandbox.Singleton
{
    public class EnemyCreator {
        private static EnemyCreator instance;
        public static EnemyCreator GetInstance() => instance ??= new EnemyCreator();

        private readonly Dictionary<EnemyName, IObjectPool<Enemy>> pools;
        private readonly bool collectionCheck = true;
        private readonly int defaultCapacity = 10;
        private readonly int maxSize = 100;

        private EnemyCreator() => pools = new();
        public Enemy Get(EnemyType type) => GetPoolFor(type).Get();
        public void Despawn(Enemy enemy) => GetPoolFor(enemy.Type).Release(enemy);

        public IObjectPool<Enemy> GetPoolFor(EnemyType type) {
            if (pools.TryGetValue(type.Name, out var pool)) return pool;

            pool = new ObjectPool<Enemy>(
                () => OnCreate(type),
                OnGet,
                OnRelease,
                OnDestroy,
                collectionCheck,
                defaultCapacity,
                maxSize
            );

            pools.Add(type.Name, pool);
            return pool;
        }

        private void OnDestroy(Enemy enemy) {
            GameObject.Destroy(enemy.gameObject);
        }

        private void OnRelease(Enemy enemy) {
            enemy.gameObject.SetActive(false);
        }

        private void OnGet(Enemy enemy) {
            enemy.gameObject.SetActive(true);
            enemy.StartDespawnCountdown();
        }

        private Enemy OnCreate(EnemyType type) {
            var enemyBuilder = new EnemyBuilder();
            enemyBuilder.SetType(type);
            return enemyBuilder.GetProduct();
        }
    }
}

