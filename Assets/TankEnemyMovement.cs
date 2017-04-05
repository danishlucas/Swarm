using UnityEngine;
using System.Collections;

public class TankEnemyMovement : MonoBehaviour
{

    private GameObject Player;
    public float movementPause=.1f;
    public float movementDelay=0f;
    public float movementSpeed=1.3f;
    private Rigidbody2D rb;
    public int deltaTime = 0;
    public int rando;
    public bool horizontal;
    private Animator animation;




    void Start()
    {
        animation = GetComponent<Animator>();
        InvokeRepeating("Move", movementDelay, movementPause);
        
        //InvokeRepeating("rotatoPotato", 0, .05f);
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
        horizontal = true;
    }

    public int RandomNum()
    {
        int rando = Random.Range(0, 16);
        return rando;
    }

    void Update()
    {
        CheckWall();
    }

        // somewhat random movement for enemy
        void Move()
    {
        deltaTime++;
        //Debug.Log(deltaTime);
        if (deltaTime >=2)
        {
            deltaTime = 0;
        }
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            if (deltaTime == 1)
            {
                rando = RandomNum();
                Debug.Log(rando);
            }
            if (rando >= 0 && rando < 4) {
                rb.velocity = new Vector2(1 * movementSpeed, 0);
                animation.SetBool("Vertical", false);
                horizontal = true;
                
            }
            if (rando >= 4 && rando < 8)
            {
                rb.velocity = new Vector2(0, 1 * movementSpeed);
                animation.SetBool("Vertical", true);
                horizontal = false;
            }

            if (rando >= 8 && rando < 12)
            {
                rb.velocity = new Vector2(-1 * movementSpeed, 0);
                animation.SetBool("Vertical", false);
                horizontal = true;

            }

            if (rando >= 12 && rando <= 16)
            {
                rb.velocity = new Vector2(0, -1 * movementSpeed);
                animation.SetBool("Vertical", true);
                horizontal = false;

            }

        }
        //Debug.Log(horizontal);
       
    }

    void CheckWall()
    {
        Debug.Log(horizontal);
        //Debug.Log(rb.velocity.y);
        if (horizontal == true && rb.velocity.x == 0)
        {

           // Debug.Log(rb.velocity.x);
            rb.velocity = new Vector2(-1 * movementSpeed, rb.velocity.y);
            
        }

        if (horizontal == false && rb.velocity.y == 0)
        {

            //Debug.Log(rb.velocity.y);

            rb.velocity = new Vector2(rb.velocity.x, -1 * movementSpeed);
            
        }
    }

    // void rotatoPotato()
    //  {
    //    if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
    //    {
    //        transform.LookAt(Player.transform.position);
    //transform.Rotate(new Vector3(0,-90, -90), Space.Self);//correcting the original rotation
    //        transform.Rotate(new Vector3(0, -90, -90), Space.Self); // need to make y always rotato to 0!!!
    //     }
    //  }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // make player take that sweet sweet damagio
        }
        if (other.tag == "Wall")
        {

            // time to make the player move away from the wall?
           
        

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

