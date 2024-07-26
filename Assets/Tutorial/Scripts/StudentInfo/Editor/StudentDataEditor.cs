using System;
using UnityEditor;
using UnityEngine;

namespace UV.Tutorial.StudentInfo
{
    public class StudentDataEditor : EditorWindow
    {
        public static string Key = "EDITOR_STUDENT_INFO";
        public Action OnClosed,OnSaved;
        StudentData _data;

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

        public static StudentData GetData()
        {
            var data = EditorPrefs.GetString(Key, "");
            if (data.Equals("")) return new();
            return JsonUtility.FromJson<StudentData>(data);
        }

        public void SaveData(StudentData data)
        {
            OnSaved?.Invoke();
            EditorPrefs.SetString(Key, JsonUtility.ToJson(data));
        }
    }


}
