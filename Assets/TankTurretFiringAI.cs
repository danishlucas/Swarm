using UnityEngine;
using System.Collections;

public class TankTurretFiringAI: MonoBehaviour
{
    private GameObject Player;
    public GameObject bullet;
    public GameObject shotSpawn;
    public float shotDelay;
    public float repeatRate;
    private bool blocked;
    public float shotSpeed;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        InvokeRepeating("rotatoPotato", 0, .05f);
        InvokeRepeating("LaunchProjectile", shotDelay, repeatRate);
    }

    void rotatoPotato()
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            transform.LookAt(Player.transform.position);
            transform.Rotate(new Vector3(0, -90, 90), Space.Self);//correcting the original rotation
                                                                  //transform.Rotate(new Vector3(0, -90, -90), Space.Self); // need to make y always rotato to 0!!!
        }
    }

    void LaunchProjectile()
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            if (!blocked)
            {
                CircleCollider2D playerCollider = Player.GetComponent<CircleCollider2D>();

                float angle = Mathf.Atan2(Player.transform.position.y - transform.position.y,
                                           Player.transform.position.x - transform.position.x);
                for (int i = -2; i < 3; i++)
                {
                    GameObject instance = Instantiate(bullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
                    Rigidbody2D rb2 = instance.GetComponent<Rigidbody2D>(); // rb2 is for the bullets
                    rb2.velocity = new Vector2(Mathf.Cos(angle + (0.17453293f * i)) * shotSpeed, Mathf.Sin(angle + (0.17453293f * i)) * shotSpeed);
                }
            }
        }
    }
}

