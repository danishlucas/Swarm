using UnityEngine;
using System.Collections;
using System;


public class KillWhenTouched : MonoBehaviour
{


    GameObject room;
    void Start()
    {
        room = GetComponent<EnemyAttributes>().room;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().isDashing == true)
            {
                Destroy(gameObject);
                EnemyCounter script = room.GetComponent<EnemyCounter>();
                script.enemyCount -= 1;
            }
            else
            {
                other.GetComponent<Attributes>().takeDamage(); // test this shit then we can push!!!!
            }
        }
    }
}


