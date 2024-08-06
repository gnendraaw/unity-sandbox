using UnityEngine;

namespace Sandbox.FactoryMethod
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Factory Method / Enemy Data")]
    public class EnemyData : ScriptableObject {
        public GameObject Prefab;
        public float Speed;
        public float Lifetime;
    }
}

