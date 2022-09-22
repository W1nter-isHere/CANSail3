using UnityEngine;

namespace Player.FirstPerson
{
    public class FPMovementController : MonoBehaviour
    {
        public float speed = 12f;
        private CharacterController _controller;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var transform1 = transform;
            var movement = transform1.right * x + transform1.forward * z;

            _controller.Move(movement * (speed * Time.deltaTime));
        }
    }
}