using UnityEngine;
using UnityEngine.UI;

namespace Sandbox.Singleton
{
    public class EnemySpawner : MonoBehaviour {
        [SerializeField] private Transform spawnpoint;
        [SerializeField] private Button spawnEnemyButton;
        [SerializeField] private EnemyType[] enemies;

        private void Awake() {
            spawnEnemyButton.onClick.AddListener(SpawnEnemy);
        }

        private void SpawnEnemy() {
            var enemy = EnemyCreator.GetInstance().Get(enemies[Random.Range(0, enemies.Length)]);
            enemy.transform.SetPositionAndRotation(spawnpoint.position, spawnpoint.rotation);
        }
    }
}

