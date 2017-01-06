using UnityEngine;
using System.Collections;

public class SpeedUpItem : MonoBehaviour {

    GameObject Player;
	void Start () {
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            PlayerController script = Player.GetComponent<PlayerController>();
            script.moveForce += .5f;
        }
    }
	
	}

