using Ardell.EventBus;
using UnityEngine;

namespace Sandbox {
    public class Hero : MonoBehaviour {
        [SerializeField] private int health;
        [SerializeField] private int mana;

        private void OnEnable() {
            EventBus.Register<PlayerEvent>(OnPlayerEvent);
        }

        private void OnDisable() {
            EventBus.Unregister<PlayerEvent>(OnPlayerEvent);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                EventBus.Publish(new PlayerEvent {
                    Health = 10,
                    Mana = 2
                });
                Debug.Log("Player event raised.");
            }
        }

        private void OnPlayerEvent(PlayerEvent @event) {
            health += @event.Health;
            mana += @event.Mana;
        }
    }
}
