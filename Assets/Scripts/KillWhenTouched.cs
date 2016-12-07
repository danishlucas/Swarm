using UnityEngine;
using System.Collections;
using System;


public class KillWhenTouched : MonoBehaviour
{


    GameObject room;
    public int whichRoom;
    void Start()
    {
        String currRoom = ("Room " + whichRoom);
        room = GameObject.Find(currRoom);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            EnemyCounter script = room.GetComponent<EnemyCounter>();
            script.enemyCount -= 1;
        }
    }
}


