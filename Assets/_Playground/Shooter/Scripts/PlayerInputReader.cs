using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox.Playground.Shooter {
    public class PlayerInputReader : IPlayerInputReader {
        private const string MOVE_ACTION_NAME = "Move";
        private const string FIRE_ACTION_NAME = "Fire";

        public event Action OnFire;

        private readonly PlayerInput input;
        private readonly InputAction moveAction;
        private readonly InputAction fireAction;

        private PlayerInputReader(PlayerInput input) {
            this.input = input;
            moveAction = input.actions[MOVE_ACTION_NAME];
            fireAction = input.actions[FIRE_ACTION_NAME];
        }

        private void RegisterCallbacks() {
            fireAction.performed += OnFireActionPerformed;
        }

        private void OnFireActionPerformed(InputAction.CallbackContext context) {
            OnFire.Invoke();
        }

        public void RegisterFireCallback(Action OnFire) {
            this.OnFire += OnFire;
        }

        public Vector2 GetMoveInput() {
            return moveAction.ReadValue<Vector2>();
        }

        public static PlayerInputReader Create(PlayerInput input) {
            var playerInput = new PlayerInputReader(input);
            playerInput.RegisterCallbacks();
            return playerInput;
        }
    }
}

