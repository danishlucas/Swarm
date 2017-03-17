using UnityEngine;
using System.Collections;
using System;


public class KillWhenTouched : MonoBehaviour
{


    GameObject room;
    void Start()
    {
        room = gameObject.transform.root.gameObject;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().isDashing == true)
            {
                gameObject.GetComponent<EnemyAttributes>().tryDropHealth();
                Destroy(gameObject);
                EnemyCounter script = room.GetComponent<EnemyCounter>();
                script.enemyCount -= 1;
            }
        }
    }
}


