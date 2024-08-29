using UnityEditor;
using UnityEngine;

namespace Kojiko.Tutorial.Callbacks
{
    /// <summary>
    /// Provides methods for manipulating the position and rotation of GameObjects in Unity
    /// </summary>
    [CreateAssetMenu(fileName = "Object Transformation Callback", menuName = "Kojiko/Tutorials/Object Transformation Callback")]
    public class ObjectTransformationCallbacks : ScriptableObject
    {
        /// <summary>
        /// The tag which is to be checked 
        /// </summary>
        [SerializeField] private string _tag = "OperateOn";

        /// <summary>
        /// The default position of the object 
        /// </summary>
        [SerializeField] private Vector3 _defaultPosition = new(5, 2, 20);

        /// <summary>
        /// The default rotation of the object
        /// </summary>
        [SerializeField] private Vector3 _defaultRotation = new(0, 0, 0);

        /// <summary>
        /// Sets the Unity Editor tool to none
        /// </summary>
        public void InitializeTool()
        {
            Tools.current = Tool.None;
        }

        /// <summary>
        /// Sets the position of the GameObject with the specified tag to the default position
        /// </summary>
        public void InitializePosition()
        {
            var obj = GameObject.FindGameObjectWithTag(_tag);
            if (obj == null) return;
            obj.transform.position = _defaultPosition;
        }

        /// <summary>
        /// Sets the rotation of the GameObject with the specified tag to the default rotation
        /// </summary>
        public void InitializeRotation()
        {
            var obj = GameObject.FindGameObjectWithTag(_tag);
            if (obj == null) return;
            obj.transform.localRotation = Quaternion.Euler(_defaultRotation);
        }

        /// <summary>
        /// Checks if the position of the GameObject with the specified tag has changed from the default position
        /// </summary>
        /// <returns>True if the position has changed, false otherwise</returns>
        public bool HasChangedPosition()
        {
            var obj = GameObject.FindGameObjectWithTag(_tag);
            if (obj == null) return true;
            return !obj.transform.position.Equals(_defaultPosition);
        }

        /// <summary>
        /// Checks if the rotation of the GameObject with the specified tag has changed from the default rotation
        /// </summary>
        /// <returns>True if the rotation has changed, false otherwise</returns>
        public bool HasChangedRotation()
        {
            var obj = GameObject.FindGameObjectWithTag(_tag);
            if (obj == null) return true;
            return obj.transform.localRotation.eulerAngles != _defaultRotation;
        }
    }
}
