using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox {
    public static class EventBus {
        private static readonly Dictionary<Type, List<Delegate>> listeners = new();

        public static void Register<T>(Action<T> listener) where T : IEvent {
            var eventType = typeof(T);

            if (!listeners.ContainsKey(eventType)) {
                listeners[eventType] = new();
            }

            listeners[eventType].Add(listener);
        }

        public static void Deregister<T>(Action<T> listener) where T : IEvent {
            var eventType = typeof(T);

            if (listeners.ContainsKey(eventType)) {
                listeners[eventType].Remove(listener);

                if (listeners[eventType].Count == 0) {
                    listeners.Remove(eventType);
                }
            }
        }

        public static void Raise<T>(T @event) where T : IEvent {
            var eventType = typeof(T);

            if (listeners.TryGetValue(eventType, out var eventTypeListeners)) {
                foreach (var listener in eventTypeListeners) {
                    (listener as Action<T>)?.Invoke(@event);
                }
            }
        }

        public static void Clear() {
            Debug.Log("Clearning Event Bus...");
            listeners.Clear();
            Debug.Log("Event Bus Cleared.");
        }

        public static int GetListenersCount() => listeners.Count;
    }
}
