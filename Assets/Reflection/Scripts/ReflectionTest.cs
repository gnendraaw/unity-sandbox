using System;
using System.Reflection;
using UnityEngine;

namespace Sandbox.Reflection {
    public class ReflectionTest : MonoBehaviour {
        private Hero _hero;
        private const BindingFlags k_bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

        [SerializeField] private int damageToSend;

        private void Awake() {
            _hero = FindObjectOfType<Hero>();
        }

        private void Update() {
            // On keypress 1, get hero's TakeDamage method and invoke it
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                Type type = _hero.GetType();
                var method = type.GetMethod("TakeDamage", k_bindingFlags);
                method.Invoke(_hero, new object[] { damageToSend });
            }
        }
    }
}
