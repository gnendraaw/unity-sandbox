using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox.Playground.Shooter
{
    public class PlayerMover : IPlayerMover {
        private const string MOVE_ACTION_NAME = "Move";
        private readonly PlayerInput input;
        private readonly InputAction moveAction;

        public PlayerMover(PlayerInput input) {
            this.input = input;
            moveAction = input.actions[MOVE_ACTION_NAME];
        }

        public void Move(Transform origin, float speed, float deltaTime) {
            Vector3 direction = moveAction.ReadValue<Vector2>();
            origin.position += deltaTime * speed * direction;
        }
    }
}

