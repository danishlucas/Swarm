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
                Attributes stats = player.GetComponent<Attributes>();
                if (stats.invulnerable)
                {
                    Debug.Log("Bullet Slain!");
                    Destroy(gameObject);
                    return;
                }
                stats.takeDamage();
                Destroy(gameObject);
            }
            if (other.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }
}