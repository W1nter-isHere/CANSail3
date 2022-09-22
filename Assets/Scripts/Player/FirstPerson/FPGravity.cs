using System;
using UnityEngine;

namespace Player.FirstPerson
{
    public class FPGravity : MonoBehaviour
    {
        public float gravity = -9.81f;
        public float groundDistance = 0.4f;
        public float jumpDistance = 3f;
        
        private Vector3 _velocity;
        private CharacterController _controller;
        private bool _isGrounded;
        
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundMask;
        
        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2;
            }
            
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(jumpDistance * -2f * gravity);
            }

            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}