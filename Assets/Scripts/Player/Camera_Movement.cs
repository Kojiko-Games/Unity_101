using UnityEngine;

namespace Kojiko.Player
{
    public class Camera_Movement : MonoBehaviour
    {
        Camera FPSCamera;
        [SerializeField,Tooltip("The sensitivity of the mouse \nDefault - [70]")] float _mouseSensitivity = 70f;

        float xRotation = 0f;

        void Start()
        {
            FPSCamera = Camera.main;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            float X = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float Y = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
            xRotation -= Y;
            this.transform.Rotate(Vector3.up * X);

            xRotation = Mathf.Clamp(xRotation, -90, 90);
            FPSCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
    }
}
