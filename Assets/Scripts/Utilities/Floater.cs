using UnityEngine;

namespace Utilities
{
    public class Floater : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private float depthBeforeSubmerged = 1f;
        [SerializeField] private float displacementAmount = 3f;
        [SerializeField] private int floaterCount = 1;
        [SerializeField] private float waterDrag = 0.99f;
        [SerializeField] private float waterAngularDrag = 0.5f;
        
        private void FixedUpdate()
        {
            var position = transform.position;
            var waveHeight = WaveManager.Instance.GetHeight(position.x);
            rigidBody.AddForceAtPosition(Physics.gravity / floaterCount, position, ForceMode.Acceleration);
            
            if (position.y < waveHeight)
            {
                var displacementMultiplier = Mathf.Clamp01((waveHeight - position.y) / depthBeforeSubmerged) * displacementAmount;
                rigidBody.AddForceAtPosition(new Vector3(0, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), position, ForceMode.Acceleration);
                rigidBody.AddForce(-rigidBody.velocity * (displacementMultiplier * waterDrag * Time.fixedDeltaTime), ForceMode.VelocityChange);
                rigidBody.AddTorque(-rigidBody.angularVelocity * (displacementMultiplier * waterAngularDrag * Time.fixedDeltaTime), ForceMode.VelocityChange);
            }
        }
    }
}