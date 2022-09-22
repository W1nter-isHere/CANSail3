using UnityEngine;

namespace Utilities
{
    public class WaveManager : MonoBehaviour
    {
        public static WaveManager Instance;

        public float waveHeight;
        public float waveLength;
        public float waveSpeed;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            
            Destroy(gameObject);
        }

        public float GetHeight(float x)
        {
            var t = x - Time.time * waveSpeed;
            var k = Mathf.PI * 2 / waveLength;
            var s = Mathf.Sin(t * k);
            var y = s * waveHeight;
            return y;
        }
    }
}