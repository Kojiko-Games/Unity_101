using UnityEngine;
using UnityEngine.Events;

namespace Kojito.Toss
{
    /// <summary>
    /// The trigger for the basket
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class BasketTrigger : MonoBehaviour
    {
        [field: Header("Tag Settings")]
        [field: SerializeField] public string BallTag { get; private set; } = "Ball";

        /// <summary>
        /// The event to be called every time a basket is scored
        /// </summary>
        [field: Header("Events")]
        [field: SerializeField] public UnityEvent OnBasket { get; private set; }

        /// <summary>
        /// Called when a new object enters the trigger or vice versa
        /// </summary>
        /// <param name="other">The collider which has entered the collider</param>
        private void OnTriggerEnter(Collider other)
        {
            //Check if the object has the correct tag
            if (!other.CompareTag(BallTag)) return;
            OnBasket?.Invoke();
        }
    }
}

