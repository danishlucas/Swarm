using UnityEngine;
using System.Collections;

public class OmniTurretAI : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shotSpawn;
    public float shotDelay;
    public float repeatRate;
    public float shotSpeed;
    private bool nesw; // north east south west OR NAH

    void Start()
    {
        
            InvokeRepeating("LaunchProjectile", shotDelay, repeatRate);
            nesw = true;

    }


    void LaunchProjectile()
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            if (nesw)
            {
                for (int i = 0; i < 4; i++)
                {
                    GameObject instance = Instantiate(bullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
                    Rigidbody2D rb2 = instance.GetComponent<Rigidbody2D>(); // rb2 is for the bullets
                    if (i == 0)
                        rb2.velocity = new Vector2(shotSpeed, 0);
                    else if (i == 1)
                        rb2.velocity = new Vector2(0, shotSpeed);
                    else if (i == 2)
                        rb2.velocity = new Vector2(-shotSpeed, 0);
                    else if (i == 3)
                        rb2.velocity = new Vector2(0, -shotSpeed);
                }
                nesw = false;
                return;
            }

            if (!nesw)
            {
                for (int i = 0; i < 4; i++)
                {
                    GameObject instance = Instantiate(bullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
                    Rigidbody2D rb2 = instance.GetComponent<Rigidbody2D>(); // rb2 is for the bullets

                    if (i == 0)
                        rb2.velocity = new Vector2(Mathf.Sin(0.78539816f) * shotSpeed, Mathf.Cos(.78539816f) * shotSpeed); // fix the rest, use this template
                    else if (i == 1)
                        rb2.velocity = new Vector2(-Mathf.Sin(0.78539816f) * shotSpeed, Mathf.Cos(0.78539816f) * shotSpeed);
                    else if (i == 2)
                        rb2.velocity = new Vector2(-Mathf.Sin(0.78539816f) * shotSpeed, -Mathf.Cos(0.78539816f) * shotSpeed);
                    else if (i == 3)
                        rb2.velocity = new Vector2(Mathf.Sin(0.78539816f) * shotSpeed, -Mathf.Cos(0.78539816f) * shotSpeed);
                }
                nesw = true;
                return;
            }
        }
    }
}
