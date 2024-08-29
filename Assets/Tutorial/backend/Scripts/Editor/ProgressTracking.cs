using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Kojiko.Tutorial
{
    using Unity.Tutorials.Core.Editor;

    /// <summary>
    /// Contains helper methods for progress tracking
    /// </summary>
    public static class ProgressTracking
    {
        /// <summary>
        /// Clears the status for all tutorials
        /// </summary>
        [MenuItem("Tutorials/Progress Tracking/Clear All Statuses")]
        public static void ClearAllStatuses()
        {
            if (EditorUtility.DisplayDialog(
                string.Empty,
                "Do you want to clear progress of every tutorial?",
                "Clear",
                "Cancel"))
            {
                var allTutorials = TutorialEditorUtils.FindAssets<Tutorial>()
                                                  .Where(t => t.ProgressTrackingEnabled);

                foreach (var tutorial in allTutorials)
                    tutorial.StopTutorial();

                Debug.Log("Tutorial progress has been cleared!");
            }
        }
    }
}

