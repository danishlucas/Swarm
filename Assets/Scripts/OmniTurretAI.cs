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
    private bool started;
    private bool paused;
    private int rotations;

    void Start()
    {
        
        //InvokeRepeating("LaunchProjectile", shotDelay, repeatRate);
        nesw = false; 
        started = false;
        rotations = 1;



    }

    void Update()
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom && !started)
        {
            started = true;
            StartCoroutine("TimedRotation");
        }
        if (!paused && started)
        {
            transform.Rotate(Vector3.forward * 88.5f * Time.deltaTime);

        }
    }

    void LaunchProjectile()
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom && started)
        {
            //Debug.Log("rotatos: " + transform.rotation.z);
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
                rotations++;
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
                rotations++;
                return;
            }
        }
    }
    IEnumerator TimedRotation()
    {
        while (true)
        {
            paused = false;
            yield return new WaitForSeconds(.5f);
            paused = true;
            yield return new WaitForSeconds(.15f);
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
                rotations++;
               ;
            }

            else if (!nesw)
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
                rotations++;
                
            }
            yield return new WaitForSecondsRealtime(.35f);
        }
    }

    
    bool checkAngle()
    {
        float angle = this.transform.eulerAngles.z;
        if (angle == 45 || angle == 90 || angle == 135 || angle == 180 || angle == -180 || angle == -135 || angle == -90 || angle == -45)
        {
            return true;

        }
        return false;
    }
    
}
