using UnityEngine;

namespace Player.FirstPerson
{
    public class FPCameraController : MonoBehaviour
    {
        public float sensitivity = 100;
        private float _xRotation;
        
        [SerializeField] private Transform playerBody;
        [SerializeField] private Transform playerCamera;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -75f, 80);
            
            playerCamera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}