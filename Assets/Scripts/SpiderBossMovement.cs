using UnityEngine;
using System.Collections;

public class SpiderBossMovement : MonoBehaviour
{
    public GameObject Player;
    // Use this for initialization
    public float movementPause;
    public float movementDelay;
    public float movementSpeed;
    private Rigidbody2D rb;
    public float lookDelay;

    private float playerPosX;
    private float playerPosY;

    void Start()
    {
        InvokeRepeating("move", movementDelay, movementPause);
        InvokeRepeating("rotatoPotato", 0, lookDelay);
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        //find angle of player to boss, using trigonometry (look up cos inverse!!!)
        playerPosX = Player.transform.position.x;
        playerPosY = Player.transform.position.y;
        float playerCompareAngle =Mathf.Rad2Deg*Mathf.Atan2((playerPosY - transform.position.y), (playerPosX - transform.position.x));
        Debug.Log(playerCompareAngle + " angle");
        float angle = transform.rotation.z; 
        if (transform.rotation.z < playerCompareAngle)
        {
            transform.Rotate(0f, 0f, Time.deltaTime * 50 );
        }
        else if (transform.rotation.z > playerCompareAngle)
        {
            transform.Rotate(0f, 0f, -Time.deltaTime * 50);
        }
    }

    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }

    void move() // somewhat random movement for enemy
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

    void rotatoPotato()
    {
        
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

