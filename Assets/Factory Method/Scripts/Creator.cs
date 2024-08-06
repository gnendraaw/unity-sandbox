using UnityEngine;

namespace Sandbox.FactoryMethod
{
    public abstract class Creator : MonoBehaviour {
        public Transform spawnPoint;

        public EnemyData[] enemyDatas;
        public bool useNewCreator = true;

        public abstract IEnemy CreateEnemy(EnemyData enemyData);
        public abstract IEnemy CreateEnemy();
        public abstract void DespawnEnemy(IEnemy enemy);

        public void SpawnEnemy() {
            Debug.Log($"Create.SpawnEnemy");

            if (useNewCreator) {
                var enemy = CreateEnemy(enemyDatas[Random.Range(0, enemyDatas.Length)]);
                enemy.SetPosition(spawnPoint.position);
                enemy.SetRotation(spawnPoint.rotation);
            } else {
                var enemy = CreateEnemy();
                enemy.SetPosition(spawnPoint.position);
                enemy.SetRotation(spawnPoint.rotation);
            }
        }
    }
}

