using UnityEngine;

namespace Sandbox.Singleton
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "Singleton / Enemy Type")]
    public class EnemyType : ScriptableObject {
        public GameObject Prefab;
        public EnemyName Name;
        public float Speed;
        public float Lifetime;
    }

    [System.Serializable]
    public enum EnemyName {
        SingleShot,
        DoubleShot
    }
}

