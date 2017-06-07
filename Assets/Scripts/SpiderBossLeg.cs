using UnityEngine;
using System.Collections;

public class SpiderBossLeg : MonoBehaviour {

    public GameObject bullet;
    public GameObject shotSpawn;
    public GameObject Player;
    public float shotDelay;
    public float repeatRate;
    public float shotSpeed;
    public int currentPair;
    public int legPair; // each column of legs, right to left
    public float adjustment; // adds to the angle a bit
    public bool doorEast;

    // Use this for initialization
    void Start () {
        currentPair = 0;
        Player = GameObject.FindWithTag("Player");
        InvokeRepeating("LaunchProjectile", shotDelay, repeatRate);
        InvokeRepeating("rotatoPotato", 0, .05f);
    }

    void LaunchProjectile()
    {
        if (Player == null)
        {
            Debug.Log("Fixeroni?");
            Player = GameObject.Find("PLAYER");
        }
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom && currentPair == legPair)
            {
              
                GameObject instance = Instantiate(bullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
                float angle = Mathf.Atan2(Player.transform.position.y - transform.position.y,
                                           Player.transform.position.x - transform.position.x);
                Rigidbody2D rb2 = instance.GetComponent<Rigidbody2D>(); // rb2 is for the bullets
                rb2.velocity = new Vector2(Mathf.Cos(angle) * shotSpeed, Mathf.Sin(angle) * shotSpeed);
            }
            currentPair++;
            if (currentPair == 4)
            {
                currentPair = 0;
            }
        }
        
    

    void rotatoPotato()
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            transform.LookAt(Player.transform.position);
            
            transform.Rotate(new Vector3(0, -90, 90), Space.Self); 
        }
    }

}
