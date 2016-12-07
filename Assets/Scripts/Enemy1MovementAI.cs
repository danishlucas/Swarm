using UnityEngine;
using System.Collections;

public class Enemy1MovementAI : MonoBehaviour {
    public GameObject Player;
    // Use this for initialization
    public float movementPause;
    public float movementDelay;
    public float movementSpeed;
    private Rigidbody2D rb;
   

    void Start () {
        InvokeRepeating("move", movementDelay, movementPause);
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
    }

	
	// Update is called once per frame
	void Update () {
	
	}

    void move() // somewhat random movement for enemy
    {
        int rando = Random.Range(0, 14);
        if (rando >= 12) 
        {
            float angle = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            rb.velocity = new Vector2(Mathf.Cos(angle) * movementSpeed, Mathf.Sin(angle) * movementSpeed);
        }
        else   
        {
            float rads = Mathf.Deg2Rad * rando * 30;
            rb.velocity = new Vector2(Mathf.Cos(rads) * movementSpeed, Mathf.Sin(rads) * movementSpeed);
        }
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // make player take that sweet sweet damagio
        }
        if (other.tag == "Wall")
        {
            Debug.Log("hit a wall!");
            // time to make the player move away from the wall?
            if (other.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }
            else if (other.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }

            if (other.transform.position.y < transform.position.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }
            else if (other.transform.position.y < transform.position.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }

        }
    }


}

