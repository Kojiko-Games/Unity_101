using System;
using UnityEditor;
using UnityEngine;

namespace Kojiko.Tutorial.Groups
{
    /// <summary>
    /// The editor window for the Tutorial Group Containers
    /// </summary>
    public class TutorialGroupContainerWindow : EditorWindow
    {
        /// <summary>
        /// Open a window with the given tutorial group container
        /// </summary>
        /// <param name="tutorialGroupContainer">The group container which is to be displayed</param>
        public static void OpenWindow(TutorialGroupContainer tutorialGroupContainer)
        {
            if (tutorialGroupContainer == null) return;

            Type inspectorType = Type.GetType("UnityEditor.InspectorWindow,UnityEditor.dll");
            var window = GetWindow<TutorialGroupContainerWindow>("", true, inspectorType);

            window._groups = tutorialGroupContainer;
            window.titleContent = new($"{tutorialGroupContainer.Name}");
            window.Show();
        }

        /// <summary>
        /// The container for which the window is being displayed
        /// </summary>
        private TutorialGroupContainer _groups;

        /// <summary>
        /// The scroll position of the editor window
        /// </summary>
        private Vector2 _scrollPosition;

        /// <summary>
        /// The style to be used for the header
        /// </summary>
        private GUIStyle _headerStyle => new(EditorStyles.helpBox)
        {
            fontSize = 40,
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
        };

        /// <summary>
        /// The style to be used for the name of the group
        /// </summary>
        private GUIStyle _groupNameStyle => new(EditorStyles.whiteBoldLabel)
        {
            fontSize = 20,
            normal = new() { textColor = Color.white }
        };

        /// <summary>
        /// The style to be used for the description of the group
        /// </summary>
        private GUIStyle _groupDescriptionStyle => new(EditorStyles.whiteBoldLabel)
        {
            fontSize = 12,
            normal = new() { textColor = new(0.6f, 0.6f, 0.6f, 1) }
        };

        private void OnGUI()
        {
            if (_groups == null)
            {
                Close();
                return;
            }

            DrawHeader();
            DrawGroups(_groups.TutorialGroups);
        }

        /// <summary>
        /// Draws the header for the window 
        /// </summary>
        private void DrawHeader()
        {
            EditorGUILayout.LabelField(_groups.Name, _headerStyle);
        }

        /// <summary>
        /// Draws the given tutorial groups 
        /// </summary>
        /// <param name="groups">The groups which are to be drawn</param>
        private void DrawGroups(TutorialGroup[] groups)
        {
            if (groups == null || groups.Length == 0)
            {
                EditorGUILayout.HelpBox("No groups were found!", MessageType.Warning);
                return;
            }

            using (var scroll = new EditorGUILayout.ScrollViewScope(_scrollPosition))
            {
                _scrollPosition = scroll.scrollPosition;
                for (int i = 0; i < groups.Length; i++)
                {
                    var group = groups[i];
                    DrawGroup(group);
                }
            }
        }

        /// <summary>
        /// Draws the gui for the given tutorial group
        /// </summary>
        /// <param name="group">The group for which the GUI is to be drawn</param>
        private void DrawGroup(TutorialGroup group)
        {
            if (group == null) return;
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                //Draw the labels
                using (new EditorGUILayout.VerticalScope())
                {
                    GUILayout.Label(group.GroupName, _groupNameStyle);
                    GUILayout.Label(group.GroupDescription, _groupDescriptionStyle);
                }

                //Draw the tutorials 
                var tutorials = group.Tutorials;
                if (tutorials == null || tutorials.Length == 0)
                {
                    EditorGUILayout.HelpBox("No tutorials under this group!", MessageType.Warning);
                    return;
                }

                for (int i = 0; i < tutorials.Length; i++)
                {
                    var tutorial = tutorials[i];

                    //If the tutorial is missing
                    if (tutorial == null)
                    {
                        EditorGUILayout.HelpBox($"Tutorial : [{i}] is missing!", MessageType.Warning);
                        continue;
                    }

                    GUIStyle buttonStyle = new(GUI.skin.button)
                    {
                        fontSize = 15,
                        fontStyle = FontStyle.Bold,
                    };

                    if (GUILayout.Button(tutorial.Title, buttonStyle))
                        tutorial.LoadTutorialProjectLayout();

                    GUILayout.Space(2);
                }
            }

            GUILayout.Space(5);
        }
    }
}
