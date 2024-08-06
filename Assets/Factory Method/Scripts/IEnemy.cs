using UnityEngine;

namespace Sandbox.FactoryMethod
{
    public interface IEnemy {
        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
    }
}

