using UnityEngine;
using System.Collections;

public class Enemy1MovementAI : MonoBehaviour {

    public GameObject Player;
    public float movementPause;
    public float movementDelay;
    public float movementSpeed;
    private Rigidbody2D rb;
   

    void Start () {

            InvokeRepeating("move", movementDelay, movementPause);
            InvokeRepeating("rotatoPotato", 0, .05f);
            rb = GetComponent<Rigidbody2D>();
            Player = GameObject.FindWithTag("Player");
    }

    // somewhat random movement for enemy
    void move() 
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            int rando = Random.Range(0, 15);
            if (rando >= 12 && rando < 15)
            {
                float angle = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
                rb.velocity = new Vector2(Mathf.Cos(angle) * movementSpeed, Mathf.Sin(angle) * movementSpeed);
            }
            else if (rando < 11)
            {
                float rads = Mathf.Deg2Rad * rando * 30;
                rb.velocity = new Vector2(Mathf.Cos(rads) * movementSpeed, Mathf.Sin(rads) * movementSpeed);
            }
            else if (rando == 15)
                rb.velocity = new Vector2(0, 0);
        }   

    }

    void rotatoPotato()
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            transform.LookAt(Player.transform.position);
            //transform.Rotate(new Vector3(0,-90, -90), Space.Self);//correcting the original rotation
            transform.Rotate(new Vector3(0, -90, -90 ), Space.Self); // need to make y always rotato to 0!!!
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

