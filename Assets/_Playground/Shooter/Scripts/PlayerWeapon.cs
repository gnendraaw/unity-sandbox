using UnityEngine.InputSystem;

namespace Sandbox.Playground.Shooter
{
    public interface IPlayerWeapon {

    }

    public class PlayerWeapon : IPlayerWeapon {
        private readonly InputAction fireAction;

        private PlayerWeapon(InputAction fireAction) {
            this.fireAction = fireAction;
        }

        private void RegisterAction() {
            fireAction.performed += OnFire;
        }

        private void OnFire(InputAction.CallbackContext context) {
            UnityEngine.Debug.Log($"PlayerWeapon.OnFire");
        }

        public void Dispose() {
            fireAction.performed -= OnFire;
        }
        
        public static PlayerWeapon Create(InputAction inputAction) {
            var playerWeapon = new PlayerWeapon(inputAction);
            playerWeapon.RegisterAction();
            return playerWeapon;
        }
    }
}

