using UnityEngine;

namespace Kojiko.Player
{
    /// <summary>
    /// The basic player movement script
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class Player_Movement : MonoBehaviour
    {
        /// <summary>
        /// The controller which moves the player 
        /// </summary>
        private CharacterController _controller;

        /// <summary>
        /// The speed which the player moves with
        /// </summary>
        [field: SerializeField, Tooltip("The speed the player moves with \nDefault : [10]")]
        public float Speed { get; set; } = 10f;

        /// <summary>
        /// The mass of the player 
        /// </summary>
        [Range(1, 20)] [SerializeField, Tooltip("The mass of the player \nDefault : [1]")] 
        private float _mass = 1;

        /// <summary>
        /// The gravity multiplier for the player 
        /// </summary>
        private float _gravity = -9.8f;

        /// <summary>
        /// The jump height of the player
        /// </summary>
        [SerializeField, Tooltip("The jump height of the player \nDefault : [3]")] 
        private float _jumpheight = 3f;

        /// <summary>
        /// The current velocity of the player
        /// </summary>
        private Vector3 _velocity;

        /// <summary>
        /// The ground check origin of the player 
        /// </summary>
        private Transform _groundCheck;

        /// <summary>
        /// The radius of the ground check 
        /// </summary>
        private float _radius = 0.3f;

        /// <summary>
        /// The ground layers for the player 
        /// </summary>
        private LayerMask _groundLayers;

        /// <summary>
        /// The flag which tells the controller whether it is grounded is not 
        /// </summary>
        private bool _isGrounded;

        /// <summary>
        /// Finds the references at Start 
        /// </summary>
        private void Start() => FindReferences();

        /// <summary>
        /// Finds the references at Reset 
        /// </summary>
        private void Reset() => FindReferences();

        /// <summary>
        /// Finds all the references that are required for the controller to function
        /// </summary>
        private void FindReferences()
        {
            _controller = GetComponent<CharacterController>();
            _groundCheck = transform.GetChild(1);
            _groundLayers = 1 << LayerMask.NameToLayer("Ground");
        }

        void Update()
        {
            //Check if the player is grounded or not
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _radius, _groundLayers);
            if (_isGrounded && _velocity.y < 0)
                _velocity.y = -2f;

            //Take input from the keyboard 
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            //Move the character based on the input 
            Vector3 move = transform.right * x + transform.forward * z;
            _controller.Move(Speed * Time.deltaTime * move);

            ManagePlayerJump();
            SimulateGravity();
        }

        /// <summary>
        /// Simulates the gravity on the player 
        /// </summary>
        private void SimulateGravity()
        {
            _velocity.y += _gravity * _mass * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }

        /// <summary>
        /// Manages the player jump
        /// </summary>
        private void ManagePlayerJump()
        {
            if (Input.GetButtonDown("Jump") && _isGrounded)
                _velocity.y = Mathf.Sqrt(_jumpheight * -2f * _gravity * _mass);
        }

        private void OnDrawGizmos()
        {
            if (_groundCheck == null) return;
            Gizmos.DrawSphere(_groundCheck.transform.position, _radius);
        }
    }
}
