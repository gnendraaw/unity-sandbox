using UnityEngine;

namespace Extensions
{
    public static class GameObjectExtentions {
        public static T GetOrAdd<T>(this GameObject go) where T : Component{
            var component = go.GetComponent<T>() ?? go.AddComponent<T>();
            return component;
        }
    }
}

