using UnityEngine;

namespace Sandbox {
    [RequireComponent(typeof(HealthComponent), typeof(ManaComponent))]
    public class Hero : MonoBehaviour {
        private HealthComponent health;
        private ManaComponent mana;

        private void OnEnable() {
            EventBus.Register<PlayerEvent>(OnPlayerEvent);
            Debug.Log("Registered to PlayerEvent.");
        }

        private void OnDisable() {
            EventBus.Deregister<PlayerEvent>(OnPlayerEvent);
            Debug.Log("Deregistered from PlayerEvent.");
        }

        private void Awake() {
            health = GetComponent<HealthComponent>();
            mana = GetComponent<ManaComponent>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                EventBus.Raise<PlayerEvent>(new PlayerEvent {
                    Health = 10,
                    Mana = 5
                });
                Debug.Log("Player Event Raised.");
            }
        }

        private void OnPlayerEvent(PlayerEvent @event) {
            Debug.Log($"Player Event Recieved! Health: {@event.Health}, Mana: {@event.Mana}");
            health.SetHealth(health.GetHealth() + @event.Health);
            mana.SetMana(mana.GetMana() + @event.Mana);
        }
    }
}
