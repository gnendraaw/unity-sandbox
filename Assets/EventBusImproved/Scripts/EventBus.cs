using System;
using System.Collections.Generic;

namespace Ardell.EventBus {
    public static class EventBus {
        private static readonly Dictionary<Type, List<Delegate>> buses = new();

        public static void Register<T>(Action<T> listener) where T : IEvent {
            var type = typeof(T);

            if (!buses.ContainsKey(type)) {
                buses[type] = new();
            }

            buses[type].Add(listener);
        }

        public static void Unregister<T>(Action<T> listener) where T : IEvent
        {
            var type = typeof(T);

            if (!buses.ContainsKey(type)) return;
                
            buses[type].Remove(listener);

            if (buses[type].Count == 0) {
                buses.Remove(type);
            }
        }

        public static void Publish<T>(T @event) where T : IEvent {
            var type = typeof(T);
            if (buses.TryGetValue(type, out var bus)) {
                foreach (var listener in bus) {
                    (listener as Action<T>)?.Invoke(@event);
                }
            }
        }

        public static void Clear() {
            buses.Clear();
        }
    }
}
