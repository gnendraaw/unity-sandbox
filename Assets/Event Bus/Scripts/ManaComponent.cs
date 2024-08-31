using UnityEngine;

namespace Sandbox {
    public class ManaComponent : MonoBehaviour {
        [SerializeField] private int maxMana;
        [SerializeField] private int currentMana;

        public int GetMaxMana() => maxMana;
        public int GetMana() => currentMana;

        public void SetMana(int Mana) => currentMana = Mana;
        public void SetMaxMana(int maxMana) => this.maxMana = maxMana;
    }
}
