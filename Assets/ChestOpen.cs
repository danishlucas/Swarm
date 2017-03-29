using UnityEngine;
using System.Collections;

public class ChestOpen : MonoBehaviour {

    private Animator animation;

	// Use this for initialization
	void Start () {
        animation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animation.SetTrigger("OpenChest");
        }
    }
}
