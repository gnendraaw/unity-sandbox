using UnityEngine;

namespace Sandbox.FactoryMethod
{
    public abstract class Creator : MonoBehaviour {
        public Transform spawnPoint;

        public abstract IEnemy CreateEnemy();
        public abstract void DespawnEnemy(IEnemy enemy);

        public void SpawnEnemy() {
            Debug.Log($"Create.SpawnEnemy");

            var enemy = CreateEnemy();
            enemy.SetPosition(spawnPoint.position);
            enemy.SetRotation(spawnPoint.rotation);
        }
    }
}

