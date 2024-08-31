using UnityEngine;

namespace Sandbox {
    public class Enemy : MonoBehaviour {
        private void OnEnable() {
            EventBus.Register<TestEvent>(OnTestEvent);
            Debug.Log("Enemy registered to TestEvent");
        }

        private void OnDisable() {
            EventBus.Deregister<TestEvent>(OnTestEvent);
            Debug.Log("Enemy deregistered from TestEvent");
        }

        private void OnTestEvent(TestEvent @event) {
            Debug.Log($"{gameObject.name} Enemy.OnTestEvent Recieved");
        }
    }
}
