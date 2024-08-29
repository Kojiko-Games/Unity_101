using System;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Kojiko.Tutorial
{
    using System.Net.Http;
    using System.Text;
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
                var tutorialWindow = typeof(TutorialWindow);
                var markUnCompleted = tutorialWindow.GetMethod("MarkAllTutorialsUncompleted", BindingFlags.NonPublic | BindingFlags.Instance);
                markUnCompleted.Invoke(TutorialWindow.Instance, null);

                Debug.Log("Tutorial Progress was reset!");
            }
        }
    }
}

