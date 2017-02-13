using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour {

    public int health;
    public int maxHealth;
    GameObject Player;
    public bool invulnerable;
    public float invulnerabilityTime;
    public float sizeChange;


    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        health = 6;
        maxHealth = 6;
        invulnerable = false;

    }
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this);
        
	}
    // called when player takes damage
    public void takeDamage()
    {
        if (this.GetComponent<PlayerController>().isDashing == true || invulnerable == true)
        {
            Debug.Log("Ha we don't take damage get rekt");

        }
        else if (health != 0)
        {

            
            invulnerable = true;
            Invoke("StopInvul", invulnerabilityTime);
            health--;
            transform.localScale -= new Vector3(sizeChange, sizeChange, 0);
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
        transform.localScale += new Vector3 (sizeChange, sizeChange, 0);
        Debug.Log("healed! health =" + health);
        this.GetComponent<PlayerController>().moveForce -= .5f;
    }

    void StopInvul()
    {
        invulnerable = false;
    }


}
