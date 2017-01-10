using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour {

    public int health;
    public float speed;
    public int maxHealth;
    GameObject Player;


	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        health = 6;
        maxHealth = 6;
        speed = 1;
        


    }
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this); // is this right?
	}
    // called when player takes damage
    public void takeDamage()
    {
        if (health != 0)
        {
            health--;
            transform.localScale -= new Vector3(.02f, .02f, 0);
            Debug.Log("Damaged! health = " + health);
            if (health <= 0)
            {
                Debug.Log("Alas! I am slain!");
            }

            this.GetComponent<PlayerController>().moveForce += .5f;
        }

    }

    public void heal()
    {
        if (health < maxHealth)
        health++;
        transform.localScale += new Vector3 (.02f, .02f, 0);
        Debug.Log("healed! health =" + health);
        this.GetComponent<PlayerController>().moveForce -= .5f;
    }

}
