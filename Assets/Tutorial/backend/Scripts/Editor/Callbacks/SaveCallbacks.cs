using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Kojiko.Tutorial.Callbacks
{
    /// <summary>
    /// Provides methods for managing scene saving operations in Unity
    /// </summary>
    [CreateAssetMenu(fileName = "Save Callback", menuName = "Kojiko/Tutorials/Save Callback")]
    public class SaveCallbacks : ScriptableObject
    {
        /// <summary>
        /// Indicates if the current scene has been saved
        /// </summary>
        private bool _sceneSaved;

        /// <summary>
        /// The current active scene
        /// </summary>
        private Scene _currentScene;

        /// <summary>
        /// Begins checking for scene save events
        /// </summary>
        public void BeginSaveCheck()
        {
            _sceneSaved = false;
            _currentScene = SceneManager.GetActiveScene();
            EditorSceneManager.sceneSaved -= SceneSaved;
            EditorSceneManager.sceneSaved += SceneSaved;
        }

        /// <summary>
        /// Callback method invoked when the scene is saved
        /// </summary>
        /// <param name="scene">The scene that was saved</param>
        void SceneSaved(Scene scene)
        {
            _sceneSaved = true;
            EditorSceneManager.sceneSaved -= SceneSaved;
        }

        /// <summary>
        /// Checks if the current scene has unsaved changes
        /// </summary>
        /// <returns>True if the scene is dirty, otherwise false</returns>
        public bool IsDirty()
        {
            return _currentScene.isDirty;
        }

        /// <summary>
        /// Waits for the current scene to be saved
        /// </summary>
        /// <returns>True if the scene is saved or not dirty, otherwise false</returns>
        public bool WaitForSceneSave()
        {
            return _currentScene.isDirty ? _sceneSaved : true;
        }

        /// <summary>
        /// Saves the current scene
        /// </summary>
        /// <returns>True if the scene was successfully saved, otherwise false</returns>
        public bool SaveScene()
        {
            SceneSaved(_currentScene);
            return _sceneSaved;
        }
    }
}
