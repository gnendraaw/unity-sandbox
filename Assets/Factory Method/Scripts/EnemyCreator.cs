using UnityEngine;
using UnityEngine.Pool;

namespace Sandbox.FactoryMethod
{
    public class EnemyCreator : Creator {
        private IObjectPool<Enemy> pool;
        private readonly bool collectionCheck = true;
        private readonly int defaultSize = 10;
        private readonly int maxSize = 100;

        public override IEnemy CreateEnemy(EnemyData data) {
            var instance = Instantiate(data.Prefab);
            instance.SetActive(false);

            var enemy = instance.GetComponent<Enemy>();
            if (!enemy)
                enemy = instance.AddComponent<Enemy>();
            
            enemy.SetPrefab(data.Prefab);
            enemy.SetSpeed(data.Speed);
            
            return enemy;
        }

        public override IEnemy CreateEnemy() {
            Debug.Log($"EnemyCreator.CreateEnemy");

            pool ??= ConstructPool();
            return pool.Get();
        }

        private ObjectPool<Enemy> ConstructPool() {
            return new ObjectPool<Enemy>(
                OnCreate,
                OnGet,
                OnRelease,
                Destroy,
                collectionCheck,
                defaultSize,
                maxSize
            );
        }

        public override void DespawnEnemy(IEnemy enemy) => pool.Release((Enemy)enemy);

        private void Destroy(Enemy enemy) {
            Destroy(enemy);
        }

        private void OnRelease(Enemy enemy) {
            enemy.gameObject.SetActive(false);
        }

        private void OnGet(Enemy enemy) {
            enemy.gameObject.SetActive(true);
        }

        private Enemy OnCreate() {
            var instance = new GameObject("Enemy"); // Update this later using scriptable object
            instance.SetActive(false);

            var enemy = instance.AddComponent<Enemy>();
            enemy.SetSpeed(7f);

            return enemy;
        }

        private Enemy ImprovedOnCreate(EnemyData data) {
            var instance = Instantiate(data.Prefab);
            instance.SetActive(false);

            var enemy = instance.GetComponent<Enemy>();
            if (!enemy)
                enemy = instance.AddComponent<Enemy>();
            
            enemy.SetPrefab(data.Prefab);
            enemy.SetSpeed(data.Speed);
            
            return enemy;
        }
    }
}

