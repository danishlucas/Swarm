using UnityEngine;
using System;
using System.Collections;


public class CheckForEnemies : MonoBehaviour
{


    public int whichRoom;
    public GameObject room;
    void Start()
    {
        String currRoom = ("Room " + whichRoom);
        //room = GameObject.Find(currRoom);

    }

    // Update is called once per frame
    void Update()
    {
        EnemyCounter script = room.GetComponent<EnemyCounter>();
        if (script.enemyCount == 0)
        {
            Destroy(gameObject);
        }
    }
}


