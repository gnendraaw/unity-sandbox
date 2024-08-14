using UnityEngine;

namespace Sandbox.Playground.Shooter {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private Transform firepoint;

        private IPlayerInputReader inputReader;
        private IPlayerMover mover;
        private IPlayerWeapon weapon;

        private void Start() {
            inputReader.RegisterFireCallback(() => weapon.Fire(firepoint));
        }

        private void Update() {
            HandleMove();
            HandleRotation();
        }

        private void HandleRotation() {
            mover.LookAt(transform, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        private void HandleMove() {
            mover.Move(inputReader.GetMoveInput(), transform, Time.deltaTime);
        }

        public void SetInputReader(IPlayerInputReader inputReader) => this.inputReader = inputReader;
        public void SetMover(IPlayerMover mover) => this.mover = mover;
        public void SetWeapon(IPlayerWeapon weapon) => this.weapon = weapon;
    }
}

