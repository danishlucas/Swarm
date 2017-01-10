using UnityEngine;
using System.Collections;

public class SpeedUpItem : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            other.GetComponent<PlayerController>().moveForce+=.5f;
            Destroy(gameObject);
        }
    }
	
	}

