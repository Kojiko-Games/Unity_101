using System;
using System.Linq;
using UnityEngine;

namespace Kojiko.Tutorial.Callbacks
{
    /// <summary>
    /// Provides utility methods for working with components and GameObjects in Unity
    /// </summary>
    public abstract class KojikoCallBack : ScriptableObject
    {
        /// <summary>
        /// Finds a GameObject by tag and retrieves a component of the specified type
        /// </summary>
        /// <typeparam name="T">The type of the component to retrieve</typeparam>
        /// <param name="tag">The tag of the GameObject</param>
        /// <returns>The component of type T if found; otherwise, null</returns>
        protected T GetComponent<T>(string tag) where T : Component
        {
            var obj = FindWithTag(tag);
            if (obj == null) return null;
            return obj.GetComponentInChildren<T>();
        }

        /// <summary>
        /// Checks if a GameObject with the specified tag has a component of the specified type
        /// </summary>
        /// <typeparam name="T">The type of the component to check for</typeparam>
        /// <param name="tag">The tag of the GameObject</param>
        /// <returns>True if the component is found; otherwise, false</returns>
        protected bool HasComponent<T>(string tag) where T : Component
        {
            return GetComponent<T>(tag) != null;
        }

        /// <summary>
        /// Finds components of the specified type in GameObjects with the specified tag, 
        /// filtering them based on the provided requirements
        /// </summary>
        /// <typeparam name="T">The type of the components to retrieve</typeparam>
        /// <param name="tag">The tag of the GameObjects</param>
        /// <param name="requirements">The filtering criteria for the components</param>
        /// <returns>An array of components that match the criteria</returns>
        protected T[] GetComponents<T>(string tag, Func<T, bool> requirements) where T : Component
        {
            var obj = GameObject.FindGameObjectWithTag(tag);
            if (obj == null) return null;
            return obj.GetComponentsInChildren<T>().Where(requirements).ToArray();
        }

        /// <summary>
        /// Finds all objects of the specified type in the scene, filtering them based on the provided requirements
        /// </summary>
        /// <typeparam name="T">The type of the components to retrieve</typeparam>
        /// <param name="requirements">The filtering criteria for the components</param>
        /// <returns>An array of components that match the criteria</returns>
        protected T[] FindObjectsOfType<T>(Func<T, bool> requirements) where T : Component
        {
            var objs = FindObjectsOfType<GameObject>(true);
            return objs
                        .Where(x => x.GetComponent<T>())
                        .Select(x => x.GetComponent<T>())
                        .Where(requirements)
                        .ToArray();
        }

        /// <summary>
        /// Finds the first GameObject with the specified tag
        /// </summary>
        /// <param name="tag">The tag of the GameObject</param>
        /// <returns>The GameObject with the specified tag if found; otherwise, null</returns>
        protected GameObject FindWithTag(string tag)
        {
            return FindObjectsOfType<GameObject>(true)
                                                    .Where(x => x.CompareTag(tag))
                                                    .FirstOrDefault();
        }
    }
}
