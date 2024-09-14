using UnityEditor;
using UnityEngine;

namespace Ardell.EventBus {
    public static class EventBusUtils {
        [InitializeOnLoadMethod]
        public static void InitializeEditor() {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state) {
            if (state == PlayModeStateChange.ExitingPlayMode) {
                ClearBuses();
            }
        }

        private static void ClearBuses() {
            Debug.Log("Clearing buses...");
            EventBus.Clear();
            Debug.Log("Buses cleared.");
        }
    }
}
