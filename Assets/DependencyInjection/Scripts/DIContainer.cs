using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ardell.DI {
    public enum Lifetime {
        Default,
        Singleton
    }

    public class DIContainer {
        static DIContainer instance;
        public static DIContainer Instance => instance ??= new DIContainer();

        private DIContainer() { }

        readonly Dictionary<Type, (Func<object>, Lifetime)> _registrations = new();
        readonly Dictionary<Type, object> _singletons = new();

        public void RegisterLazySingleton<T>(Func<T> factory) where T : class {
            var type = typeof(T);

            if (!_registrations.ContainsKey(type)) {
                _registrations.Add(type, (factory, Lifetime.Singleton));
                Debug.Log($"Type '{type.Name}' registered");
            } else {
                throw new Exception($"Type '{type.Name}' already registered.");
            }
        }

        public void Register<T>(Func<T> factory) where T : class {
            var type = typeof(T);

            if (_registrations.ContainsKey(type)) {
                _registrations.Add(type, (factory, Lifetime.Default));
                Debug.Log($"Type '{type.Name}' registered");
            } else {
                throw new Exception($"Type '{type.Name}' already registered.");
            }
        }

        public T Resolve<T>() where T : class {
            var type = typeof(T);

            // Check if the dependency has been registered.
            if (_registrations.TryGetValue(type, out var entry)) {
                var (factory, lifetime) = entry;

                return lifetime switch {
                    Lifetime.Singleton => GetOrCreateSingleton(type, factory) as T,
                    Lifetime.Default => factory() as T,
                    _ => null,
                };
            } else {
                throw new Exception($"Type '{type.Name}' is not registered.");
            }
        }

        private object GetOrCreateSingleton(Type type, Func<object> factory) {
            if (!_singletons.ContainsKey(type)) {
                _singletons.Add(type, factory());
                Debug.Log($"Singleton of type '{type.Name}' created.");
            }
            return _singletons[type];
        }
    }
}
