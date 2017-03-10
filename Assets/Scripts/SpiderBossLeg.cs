using UnityEngine;
using System.Collections;

public class SpiderBossLeg : MonoBehaviour {

    public GameObject bullet;
    public GameObject shotSpawn;
    public float shotDelay;
    public float repeatRate;
    public float shotSpeed;
    public int currentPair;
    public int legPair; // each column of legs, right to left
    public float adjustment; // adds to the angle a bit

    // Use this for initialization
    void Start () {
        currentPair = 0;
        InvokeRepeating("LaunchProjectile", shotDelay, repeatRate);
    }

    void LaunchProjectile()
    {
        
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom && currentPair == legPair)
        {
            float angle = Random.Range(0, 78539816);
            angle /= 100000000;
            GameObject instance = Instantiate(bullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
            Rigidbody2D rb2 = instance.GetComponent<Rigidbody2D>(); // rb2 is for the bullets
            rb2.velocity = new Vector2(Mathf.Cos(angle + adjustment) * shotSpeed, Mathf.Sin(angle + adjustment) * shotSpeed);
        }
        currentPair++;
        if (currentPair == 4)
        {
            currentPair = 0;
        }
    }
    
}
