using UnityEngine;
using System.Collections;

public class SpiderBossFiring : MonoBehaviour {

    public GameObject bigBullet;
    public GameObject smallBullet;
    public GameObject shotSpawn;
    public float shotDelay;
    public float repeatRate;
    public float shotSpeed;
    public GameObject Player;
    public int shotsFired;
    public int patternsCompleted;
    public bool startedMachineGun;
    public bool doorEast;

    // Use this for initialization
    void Start () {
        InvokeRepeating("LaunchProjectile", shotDelay, repeatRate);
        Player = GameObject.FindWithTag("Player");
        shotsFired = 0;
    }

    void LaunchProjectile()
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            if (shotsFired < 3 + patternsCompleted * 4)
            { // shotgun spread 3 times each rotation
                float angle = Mathf.Atan2(Player.transform.position.y - transform.position.y,
                                               Player.transform.position.x - transform.position.x);
                for (int i = -2; i < 3; i++)
                {
                    GameObject instance = Instantiate(bigBullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
                    Rigidbody2D rb2 = instance.GetComponent<Rigidbody2D>(); // rb2 is for the bullets
                    rb2.velocity = new Vector2(Mathf.Cos(angle + (0.17453293f * i)) * shotSpeed, Mathf.Sin(angle + (0.22f * i)) * shotSpeed);
                }
                shotsFired++;
            }
            else if (shotsFired < 4 + patternsCompleted * 4 && !startedMachineGun)
            {
                
                Debug.Log("step 1");
                startedMachineGun = true;
                if (Random.Range(0, 2) == 0)
                    StartCoroutine("MachineGunHelper1");
                else
                    StartCoroutine("MachineGunHelper2");
            }
            
        }
    }
    
    IEnumerator MachineGunHelper1()
    {
        for (int i = 25; i > -25; i--)
        {
            GameObject instance = Instantiate(smallBullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
            Rigidbody2D rb2 = instance.GetComponent<Rigidbody2D>(); // rb2 is for the bullets
            if (!doorEast) 
                rb2.velocity = new Vector2(Mathf.Cos((0.035f * i) + Mathf.PI) * (shotSpeed + 2), Mathf.Sin((0.035f * i) + Mathf.PI) * (shotSpeed + 2));
            else
                rb2.velocity = new Vector2(Mathf.Cos((0.035f * i)) * (shotSpeed + 2), Mathf.Sin((0.035f * i)) * (shotSpeed + 2));
            yield return new WaitForSeconds(.02f);
        }
        startedMachineGun = false;
        shotsFired++;
        patternsCompleted++;
    }
    IEnumerator MachineGunHelper2()
    {
        for (int i = -25; i < 25; i++)
        {
            GameObject instance = Instantiate(smallBullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
            Rigidbody2D rb2 = instance.GetComponent<Rigidbody2D>(); // rb2 is for the bullets
            if (!doorEast)
                rb2.velocity = new Vector2(Mathf.Cos((0.035f * i) + Mathf.PI) * (shotSpeed + 2), Mathf.Sin((0.035f * i) + Mathf.PI) * (shotSpeed + 2));
            else
                rb2.velocity = new Vector2(Mathf.Cos((0.035f * i)) * (shotSpeed + 2), Mathf.Sin((0.035f * i)) * (shotSpeed + 2));
            yield return new WaitForSeconds(.02f);
        }
        startedMachineGun = false;
        shotsFired++;
        patternsCompleted++;
    }
}
