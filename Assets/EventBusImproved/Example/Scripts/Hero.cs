using System;
using Ardell.EventBus;
using UnityEngine;

namespace Sandbox {
    public class Hero : MonoBehaviour {
        [SerializeField] private int health;
        [SerializeField] private int mana;

        private EventBinding<PlayerEvent> playerEventBinding;

        private void OnEnable() {
            EventBus<PlayerEvent>.Register(playerEventBinding);
        }

        private void OnDisable() {
            EventBus<PlayerEvent>.Unregister(playerEventBinding);
        }

        private void Awake() {
            playerEventBinding = new EventBinding<PlayerEvent>(HandlePlayerEvent);
        }

        private void HandlePlayerEvent(PlayerEvent @event) {
            Debug.Log($"Player event received! Health: {@event.Health}, Mana: {@event.Mana}");
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                EventBus<PlayerEvent>.Raise(new PlayerEvent {
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
