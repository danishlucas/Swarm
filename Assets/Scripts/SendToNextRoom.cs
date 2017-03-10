﻿using UnityEngine;
using System.Collections;


public class SendToNextRoom : MonoBehaviour
{


    public int dir; // 1 = north, 2 = east, 3 = south, 4 = west
    private Animator animation;
    public GameObject room;
    private bool active;

    // Use this for initialization
    void Start()
    {
        active = false;
        animation = GetComponent<Animator>();
        

    }

    void Update()
    {
        EnemyCounter script = room.GetComponent<EnemyCounter>();
        if (script.enemyCount == 0 && !active)
        {
            animation.SetTrigger("EnemiesDead");
            active = true;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && active)
        {
            StartCoroutine(FixActive());
            Debug.Log("Collision bro?");
            if (dir == 1)
            {
                Debug.Log("Norf");
                other.transform.Translate(Vector2.up * 4.5f, Camera.main.transform);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(0, 11, 0);
            }
            if (dir == 2)
            {
                Debug.Log("I thought you said Weast");
                other.transform.Translate(Vector2.right * 4.5f, Camera.main.transform);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(16, 0, 0);
            }
            if (dir == 3)
            {
                Debug.Log("Southernly");
                other.transform.Translate(Vector2.down * 4.5f, Camera.main.transform);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(0, -11, 0);
            }
            if (dir == 4)
            {
                Debug.Log("real west side");

                other.transform.Translate(Vector2.left * 4.5f, Camera.main.transform);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(-16, 0, 0);
            }
        }
    }
    
    IEnumerator FixActive()
    {
        active = false;
        yield return new WaitForSeconds(1);
        active = true;

    }
}


