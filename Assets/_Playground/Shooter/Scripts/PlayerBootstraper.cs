using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox.Playground.Shooter {
    [DefaultExecutionOrder(-999)]
    public class PlayerBootstraper : MonoBehaviour {
        [SerializeField] private Player player;
        [SerializeField] private PlayerData data;

        private void Awake() {
            player.SetInputReader(
                PlayerInputReader.Create(player.GetComponent<PlayerInput>())
            );
            player.SetMover(new PlayerMover(data.Speed));
            player.SetWeapon(new PlayerWeapon());
        }
    }
}

