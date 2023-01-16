using UnityEngine;

namespace Ship
{
    public class Hull : MonoBehaviour
    {
        public int Health;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Health -= 1;
        }
    }
}
