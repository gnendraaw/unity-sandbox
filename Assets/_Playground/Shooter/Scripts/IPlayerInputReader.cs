using System;
using UnityEngine;

namespace Sandbox.Playground.Shooter {
    public interface IPlayerInputReader {
        void RegisterFireCallback(Action OnFire);
        Vector2 GetMoveInput();
    }
}

