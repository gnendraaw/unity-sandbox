using UnityEngine;

namespace Sandbox.Playground.Shooter
{
    [CreateAssetMenu(fileName = "ProjecitleData", menuName = "Playground / Shooter / Projectile Data")]
    public class ProjectileData : ScriptableObject {
        public GameObject Prefab;
        public float Speed;
        public float LifeTime;
        public ProjectileType Type;
    }

    [System.Serializable]
    public enum ProjectileType {
        Square,
        Circle
    }
}

