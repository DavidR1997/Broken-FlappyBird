using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        public float upForce;           // Upward force of the "flap"
        public bool isDead = false;    // Has the player collider with the wall? 
        private Rigidbody2D rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        public void Flap()
        {
            // Only flap if the Bird isn't dead yet
            if (!isDead)
            {
                rigid.velocity = Vector2.zero;
                // Give the bird some upward force
                rigid.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            // Cancel velocity
            rigid.velocity = Vector2.zero;
            Mathf.Clamp(rigid.rotation, 0 ,0);
            // Bird is now dead
            isDead = true;
            // Tell the GameManager about it
            GameManager.Instance.BirdDied();
        }
    }
}