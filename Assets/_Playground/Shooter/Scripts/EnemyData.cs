using UnityEngine;

namespace Sandbox.Playground.Shooter {
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Playground / Shooter / Enemy Data")]
    public class EnemyData : ScriptableObject {
        public GameObject Prefab;
        public float Speed;
        public float LifeTime;
        public EnemyType Type;
    }

    [System.Serializable]
    public enum EnemyType {
        Triangle,
        Circle,
        Square
    }
}

