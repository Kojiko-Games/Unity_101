using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Kojiko.Tutorial.Callbacks
{
    /// <summary>
    /// Provides utility methods for managing objects and editor actions in Unity
    /// </summary>
    [CreateAssetMenu(menuName = "Kojiko/Tutorials/Helper Callbacks", fileName = "Helper Callbacks")]
    public class Helpers : KojikoCallBack
    {
        /// <summary>
        /// Focuses the Project window on a specific asset at the given path
        /// </summary>
        /// <param name="path">The relative path of the asset within the Assets folder</param>
        public void FocusOn(string path)
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = AssetDatabase.LoadAssetAtPath<Object>($"Assets/{path}");
        }

        /// <summary>
        /// Starts the game in Play mode in the Unity Editor
        /// </summary>
        public void StartGame()
        {
            EditorApplication.EnterPlaymode();
        }

        /// <summary>
        /// Stops the game from Play mode in the Unity Editor
        /// </summary>
        public void StopGame()
        {
            EditorApplication.ExitPlaymode();
        }

        /// <summary>
        /// Focuses on a specific editor window by its name
        /// </summary>
        /// <param name="windowName">The name of the window to focus on</param>
        public void FocusOnWindow(string windowName)
        {
            try
            {
                EditorWindow window = EditorWindow.GetWindow(Type.GetType($"UnityEditor.{windowName},UnityEditor"));
                if (window != null)
                    window.Focus();
            }
            catch { }
        }

        /// <summary>
        /// Selects a GameObject in the scene by its tag
        /// </summary>
        /// <param name="tag">The tag of the GameObject to select</param>
        public void SelectObject(string tag)
        {
            Selection.activeGameObject = FindWithTag(tag);
        }

        /// <summary>
        /// Enables a GameObject in the scene by its tag
        /// </summary>
        /// <param name="tag">The tag of the GameObject to enable</param>
        public void EnableObject(string tag) => SetObject(FindWithTag(tag), true);

        /// <summary>
        /// Disables a GameObject in the scene by its tag
        /// </summary>
        /// <param name="tag">The tag of the GameObject to disable</param>
        public void DisableObject(string tag) => SetObject(FindWithTag(tag), false);

        /// <summary>
        /// Sets the active state of a GameObject
        /// </summary>
        /// <param name="obj">The GameObject to set active or inactive</param>
        /// <param name="what">True to activate, false to deactivate</param>
        public void SetObject(GameObject obj, bool what)
        {
            if (obj == null) return;
            obj.SetActive(what);
        }
    }
}
