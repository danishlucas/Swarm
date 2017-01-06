using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour {

    public int health;
    public float speed;
    public float size;
    public int maxHealth;


	// Use this for initialization
	void Start () {
        health = 6;
        maxHealth = 6;
        size = 1.0f;
        speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this); // is this right?
	}
    // called when player takes damage
    public void takeDamage()
    {
        health--;
        transform.localScale -= new Vector3(.03f, .03f, 0);
    }

    public void heal()
    {
        health++;
        transform.localScale += new Vector3 (.03f, .03f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
