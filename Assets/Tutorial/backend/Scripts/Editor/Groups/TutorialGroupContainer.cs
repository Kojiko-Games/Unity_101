using UnityEngine;
using Unity.Tutorials.Core.Editor;

namespace Kojiko.Tutorial.Groups
{
    /// <summary>
    /// Defines a tutorial group container; A collection of tutorial groups
    /// </summary>
    [CreateAssetMenu(menuName = "Kojiko/Tutorials/Tutorial Group Container", fileName = "New Tutorial Group Container")]
    public class TutorialGroupContainer : ScriptableObject
    {
        /// <summary>
        /// The name of the group container
        /// </summary>
        [field: Header("Basic Settings")]
        [field: SerializeField] public string Name = "Group";

        /// <summary>
        /// All the tutorial groups under this container
        /// </summary>
        [field: Header("Groups")]
        [field: SerializeField] public TutorialGroup[] TutorialGroups { get; private set; }

        /// <summary>
        /// Opens this group container in a window
        /// </summary>
        public void ShowWindow()
        {
            TutorialGroupContainerWindow.OpenWindow(this);
        }
    }

    /// <summary>
    /// Defines a tutorial group; Contains a set of tutorials with a name
    /// </summary>
    [System.Serializable]
    public class TutorialGroup
    {
        /// <summary>
        /// The name of the tutorial group
        /// </summary>
        [field: SerializeField] public string GroupName { get; private set; }

        /// <summary>
        /// The description of the tutorial group
        /// </summary>
        [field: SerializeField, TextArea(1, 5)] public string GroupDescription { get; private set; }

        /// <summary>
        /// The tutorials under the tutorial group
        /// </summary>
        [field: SerializeField] public TutorialContainer[] Tutorials { get; private set; }
    }
}

