using UnityEngine;

namespace Sandbox.Flyweight {
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "Flyweight / Projectile Data")]
    public class ProjectileData : ScriptableObject {
        public GameObject Prefab;
        public float LifeTime;
        public float Speed;
        public ProjectileType Type;
    }

    [System.Serializable]
    public enum ProjectileType {
        Square,
        Triangle,
        Circle
    }
}

