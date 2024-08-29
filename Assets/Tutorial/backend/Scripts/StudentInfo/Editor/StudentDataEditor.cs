using System;
using UnityEditor;
using UnityEngine;

namespace Kojiko.Tutorial.StudentInfo
{
    /// <summary>
    /// Editor window for entering and managing student data
    /// </summary>
    public class StudentDataEditor : EditorWindow
    {
        /// <summary>
        /// Key for storing student data in EditorPrefs
        /// </summary>
        public static string Key = "EDITOR_STUDENT_INFO";

        /// <summary>
        /// Event triggered when the window is closed
        /// </summary>
        public Action OnClosed;

        /// <summary>
        /// Event triggered when data is saved
        /// </summary>
        public Action OnSaved;

        /// <summary>
        /// The current student data being edited
        /// </summary>
        private StudentData _data;

        /// <summary>
        /// Opens the StudentDataEditor window
        /// </summary>
        /// <param name="onWindowShown">Callback action when the window is shown</param>
        [MenuItem("Student Data/Enter Data")]
        public static void Init(Action<StudentDataEditor> onWindowShown)
        {
            var window = GetWindow<StudentDataEditor>("Update the data");
            window.Show();
            onWindowShown.Invoke(window);
        }

        private void OnGUI()
        {
            _data ??= GetData();

            EditorGUILayout.LabelField("Name - ");
            _data.Name = EditorGUILayout.TextField(_data.Name);

            EditorGUILayout.LabelField("School - ");
            _data.School = EditorGUILayout.TextField(_data.School);

            if (GUILayout.Button("Save"))
                SaveData(_data);
        }

        /// <summary>
        /// Retrieves the student data from EditorPrefs
        /// </summary>
        /// <returns>The retrieved StudentData object</returns>
        public static StudentData GetData()
        {
            var data = EditorPrefs.GetString(Key, "");
            if (data.Equals("")) return new();
            return JsonUtility.FromJson<StudentData>(data);
        }

        /// <summary>
        /// Saves the student data to EditorPrefs
        /// </summary>
        /// <param name="data">The student data to save</param>
        public void SaveData(StudentData data)
        {
            OnSaved?.Invoke();
            EditorPrefs.SetString(Key, JsonUtility.ToJson(data));
        }
    }
}
