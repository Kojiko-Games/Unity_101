using UnityEngine;
using UnityEngine.Events;

namespace Kojiko.Tutorial.StudentInfo
{
    /// <summary>
    /// Manages the student data editor window and events
    /// </summary>
    [CreateAssetMenu(fileName = "Student Data Carrier", menuName = "Kojiko/Student Data/Student Data Carrier")]
    public class StudentDataCarrier : ScriptableObject
    {
        [SerializeField] UnityEvent _onSaved;

        /// <summary>
        /// Opens the student data editor window and sets up event handlers
        /// </summary>
        public void OpenWindow()
        {
            StudentDataEditor.Init((x) =>
            {
                x.OnClosed += OnFinishedEditing;
                x.OnSaved += OnFinishedEditing;
            });
        }

        /// <summary>
        /// Invokes the onSaved event when editing is finished
        /// </summary>
        void OnFinishedEditing()
        {
            _onSaved?.Invoke();
        }
    }
}
