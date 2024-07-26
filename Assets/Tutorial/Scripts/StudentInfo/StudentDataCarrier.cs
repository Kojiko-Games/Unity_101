using UnityEngine;
using UnityEngine.Events;

namespace UV.Tutorial.StudentInfo
{
    [CreateAssetMenu(fileName = "Student Data Carrier", menuName = "UV/Student Data/Student Data Carrier")]
    public class StudentDataCarrier : ScriptableObject
    {
        [SerializeField] UnityEvent _onSaved;

        public void OpenWindow()
        {
            StudentDataEditor.Init((x) =>
            {
                x.OnClosed += OnFinishedEditing;
                x.OnSaved += OnFinishedEditing;
            });
        }

        void OnFinishedEditing()
        {
            _onSaved?.Invoke();
        }
    }
}
