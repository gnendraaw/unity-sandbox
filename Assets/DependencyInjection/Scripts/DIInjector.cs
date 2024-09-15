using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Ardell.DI {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public sealed class InjectAttribute : Attribute {
        public InjectAttribute() { }
    }

    public static class DIInjector {
        const BindingFlags k_bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        [RuntimeInitializeOnLoadMethod]
        static void Init() {
            var monoBehaviours = FindMonoBehaviours();

            // Gather all dependency installers and register dependencies by install method.
            InitInstallers(monoBehaviours);

            // Find monobehaviours implementing inject attribute & inject required dependencies.
            var injectables = monoBehaviours.Where(IsInjectable);
            Debug.Log($"Injectable retreived. Count: {injectables.Count()}");
            
            foreach (var injectable in injectables) {
                Inject(injectable);
            }
        }

        private static void Inject(MonoBehaviour instance) {
            var type = instance.GetType();

            // Inject into fields
            var fields = type.GetFields(k_bindingFlags)
                .Where(member => Attribute.IsDefined(member, typeof(InjectAttribute)));
            
            foreach (var field in fields) {
                var fieldType = field.FieldType;
                var resolvedInstance = Resolve(fieldType);

                if (resolvedInstance == null) {
                    throw new Exception($"Failed to inject dependency into field {field.Name} of class {type.Name}.");
                }

                field.SetValue(instance, resolvedInstance);
                Debug.Log($"Injected dependency of type '{fieldType.Name}' field of class {type.Name}.");
            }

            // Inject into methods
            var methods = type.GetMethods(k_bindingFlags)
                .Where(member => Attribute.IsDefined(member, typeof(InjectAttribute)));
            
            foreach (var method in methods) {
                var requiredParameters = method.GetParameters()
                    .Select(parameter => parameter.ParameterType)
                    .ToArray();
                var resolvedInstances = requiredParameters.Select(Resolve).ToArray();

                if (resolvedInstances.Any(instance => instance == null)) {
                    throw new Exception($"Failed to inject dependency into method {method.Name} of class {type.Name}");
                }

                method.Invoke(instance, resolvedInstances);
                Debug.Log($"Injected dependency by method of class {type.Name}");
            }
        }

        private static object Resolve(Type fieldType) {
            var result = DIContainer.Instance.Resolve(fieldType);

            if (result == null) {
                throw new Exception($"Failed to resolve dependency of type '{fieldType.Name}'");
            }

            Debug.Log($"Resolved dependency of type '{fieldType.Name}'");

            return result;
        }

        private static bool IsInjectable(MonoBehaviour behaviour) {
            var members = behaviour.GetType().GetMembers(k_bindingFlags);
            return members.Any(member => Attribute.IsDefined(member, typeof(InjectAttribute)));
        }

        private static void InitInstallers(MonoBehaviour[] monoBehaviours) {
            Debug.Log("Initializing installers...");

            var installers = monoBehaviours.OfType<IDependencyInstaller>();
            if (installers != null) {
                Debug.Log($"Installers retreived. count: {installers.Count()}");
            }

            foreach (var installer in installers) {
                var type = installer.GetType();
                var method = type.GetMethod("Install", k_bindingFlags);
                method?.Invoke(installer, null);
                Debug.Log($"Dependencies in {type.Name} installed");
            }
        }

        static MonoBehaviour[] FindMonoBehaviours() => MonoBehaviour.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID);
    }
}