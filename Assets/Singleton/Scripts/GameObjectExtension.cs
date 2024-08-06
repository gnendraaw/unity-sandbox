using UnityEngine;

namespace Sandbox.Extension
{
    public static class GameObjectExtension {
        public static T GetOrAdd<T>(this GameObject go) where T : Component {
            var component = go.GetComponent<T>();
            return component ?? go.AddComponent<T>();
        }
    }
}

