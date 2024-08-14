using UnityEngine;
using Utils;

namespace Sandbox.Playground.Shooter {
    public class EnemySpawner : Singleton<EnemySpawner> {
        #region Fields
        [SerializeField] private EnemyData[] enemies;
        [SerializeField] private float spawnInterval;
        [SerializeField] private Transform spawnPoint;

        private CountdownTimer spawnTimer;
        private EnemyBuilder enemyBuilder;

        [Header("Settings")]
        public bool spawnRandomEnemy;
        #endregion

        private void Awake() {
            Setup();
        }

        private void Setup() {
            enemyBuilder = new EnemyBuilder();
            spawnTimer = new CountdownTimer(spawnInterval);
        }

        private void Update() {
            HandleSpawningEnemy();
        }

        private void HandleSpawningEnemy() {
            spawnTimer.Tick(Time.deltaTime);
            if (!spawnTimer.IsRunning()) {
                spawnTimer.Reset();

                if (spawnRandomEnemy) {
                    SpawnRandomEnemy();
                } else {
                    SpawnEnemy(enemies[0]);
                }
            }
        }

        private void SpawnRandomEnemy() {
            SpawnEnemy(enemies[UnityEngine.Random.Range(0, enemies.Length)]);
        }

        private void SpawnEnemy(EnemyData enemyData) {
            // Possible optimization - Enemy Pool
            var enemy = CreateEnemy(enemyData);
            enemy.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        }

        private EnemyController CreateEnemy(EnemyData enemyData) {
            enemyBuilder.Reset();
            enemyBuilder.SetEnemyData(enemyData);
            return enemyBuilder.GetProduct();
        }
    }
}

