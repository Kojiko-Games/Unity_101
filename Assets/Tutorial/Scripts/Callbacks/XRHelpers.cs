using UnityEngine;

namespace Kojiko.Tutorial.Callbacks
{
    /// <summary>
    /// Provides helper methods for working with XR interactions
    /// </summary>
    [CreateAssetMenu(menuName = "Kojiko/Tutorials/XR Helper Callbacks", fileName = "XR Helper Callbacks")]
    public class XRHelpers : KojikoCallBack
    {
        /// <summary>
        /// Checks if an object with the specified tag has an XRGrabInteractable component
        /// </summary>
        /// <param name="tag">The tag of the object to check</param>
        /// <returns>True if the object has an XRGrabInteractable component, otherwise false</returns>
        public bool HasInteractable(string tag)
        {
            return HasComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>(tag);
        }

        /// <summary>
        /// Checks if an object with the specified tag has an XRGrabInteractable component that uses dynamic attachment
        /// </summary>
        /// <param name="tag">The tag of the object to check</param>
        /// <returns>True if the object has dynamic attachment, otherwise false</returns>
        public bool DynamicAttach(string tag)
        {
            var _grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>(tag);
            return _grabInteractable == null || _grabInteractable.useDynamicAttach;
        }

        /// <summary>
        /// Checks if an object with the specified tag has an XRSocketInteractor component with a non-null attachTransform
        /// </summary>
        /// <param name="tag">The tag of the object to check</param>
        /// <returns>True if the object has a valid attachTransform, otherwise false</returns>
        public bool HasAttackPoint(string tag)
        {
            var _grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>(tag);
            return _grabInteractable == null || _grabInteractable.attachTransform != null;
        }

        /// <summary>
        /// Checks if an object with the specified tag has an XRSocketInteractor component
        /// </summary>
        /// <param name="tag">The tag of the object to check</param>
        /// <returns>True if the object has an XRSocketInteractor component, otherwise false</returns>
        public bool HasSocket(string tag)
        {
            return HasComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>(tag);
        }
    }
}
