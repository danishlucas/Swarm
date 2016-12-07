using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class BulletCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                var player = GameObject.FindWithTag("Player");
               // player.GetComponent(OtherScript) // use this to make the player take damage later
                Destroy(gameObject);
            }
            if (other.tag == "Wall")
            {
                
                Destroy(gameObject);
            }
        }
    }
}