using UnityEngine;

namespace Kojito.Player
{
    public class BasicPlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _moveSpeed = 10;

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
                _controller.Move(_moveSpeed * Time.deltaTime * Vector3.forward);

            if (Input.GetKey(KeyCode.S))
                _controller.Move(_moveSpeed * Time.deltaTime * -Vector3.forward);

            if (Input.GetKey(KeyCode.A))
                _controller.Move(_moveSpeed * Time.deltaTime * -Vector3.right);

            if (Input.GetKey(KeyCode.D))
                _controller.Move(_moveSpeed * Time.deltaTime * Vector3.right);
        }
    }
}
