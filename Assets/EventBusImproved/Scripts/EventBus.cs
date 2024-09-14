using System.Collections.Generic;
using UnityEngine;

namespace Ardell.EventBus {
    public static class EventBus<T> where T : IEvent {
        private static readonly HashSet<IEventBinding<T>> bindings = new();

        public static void Register(IEventBinding<T> binding) => bindings.Add(binding);
        public static void Unregister(IEventBinding<T> binding) => bindings.Remove(binding);

        public static void Raise(T @event) {
            foreach (var binding in bindings) {
                binding.OnEventNoArgs?.Invoke();
                binding.OnEvent?.Invoke(@event);
            }
        }

        static void Clear() {
            Debug.Log($"Clearing {typeof(T).Name} bindings...");
            bindings.Clear();
        }
    }
}
