using UnityEngine;

namespace Sandbox {
    public class HealthComponent : MonoBehaviour {
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;

        public int GetMaxHealth() => maxHealth;
        public int GetHealth() => currentHealth;

        public void SetHealth(int health) => currentHealth = health;
        public void SetMaxHealth(int maxHealth) => this.maxHealth = maxHealth;
    }
}
