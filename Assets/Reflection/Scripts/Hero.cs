using UnityEngine;

namespace Sandbox.Reflection {
    public class Hero : MonoBehaviour {
        [SerializeField] private Settings _settings;

        private int currentHealth;

        private void Awake() {
            currentHealth = _settings.MaxHealth;
        }

        private void TakeDamage(int damage) {
            currentHealth = Mathf.Max(currentHealth-damage, 0);
            Debug.Log($"Hero.TakeDamage({damage}); Remaining health: {currentHealth}");
        }

        [System.Serializable]
        public class Settings {
            public int MaxHealth;
        }
    }
}
