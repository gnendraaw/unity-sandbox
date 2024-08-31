using UnityEngine;

namespace Sandbox {
    [RequireComponent(typeof(HealthComponent), typeof(ManaComponent))]
    public class Hero : MonoBehaviour {
        private HealthComponent health;
        private ManaComponent mana;

        private void OnEnable() {
            EventBus.Register<PlayerEvent>(OnPlayerEvent);
            Debug.Log("Player registered to PlayerEvent");

            EventBus.Register<TestEvent>(OnTestEvent);
            Debug.Log("Player registered to TestEvent");
        }

        private void OnDisable() {
            EventBus.Deregister<PlayerEvent>(OnPlayerEvent);
            Debug.Log("Player deregistred from PlayerEvent");

            EventBus.Deregister<TestEvent>(OnTestEvent);
            Debug.Log("Player deregistred from TestEvent");
        }

        private void Awake() {
            health = GetComponent<HealthComponent>();
            mana = GetComponent<ManaComponent>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                EventBus.Raise(new PlayerEvent {
                    Health = 10,
                    Mana = 5
                });

                Debug.Log("Player Event Raised.");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                EventBus.Raise(new TestEvent());

                Debug.Log("Test Event Raised.");
            }
        }

        private void OnPlayerEvent(PlayerEvent @event) {
            Debug.Log($"Player Event Recieved! Health: {@event.Health}, Mana: {@event.Mana}");
            health.SetHealth(health.GetHealth() + @event.Health);
            mana.SetMana(mana.GetMana() + @event.Mana);
        }

        private void OnTestEvent(TestEvent @event) {
            Debug.Log("Improved EventBus; Test Event Recieved");
        }
    }
}
