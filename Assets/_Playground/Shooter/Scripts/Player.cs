using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox.Playground.Shooter {
    public class Player : MonoBehaviour {
        [SerializeField] private float speed;

        private IPlayerMover mover;
        private IPlayerWeapon weapon;

        private void Awake() {
            var playerInput = GetComponent<PlayerInput>();
            mover = new PlayerMover(playerInput);
            weapon = PlayerWeapon.Create(playerInput.actions["Fire"]);
        }

        private void Update() {
            mover.Move(transform, speed, Time.deltaTime);
        }
    }
}

