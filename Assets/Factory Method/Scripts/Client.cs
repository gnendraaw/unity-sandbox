using UnityEngine;

namespace Sandbox.FactoryMethod
{
    // Act as Enemy Spawner
    public class Client : MonoBehaviour {
        private Creator enemySpawner;

        private void Awake() {
            enemySpawner = FindObjectOfType<Creator>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.T)) {
                enemySpawner.SpawnEnemy();
            }
        }
    }
}

