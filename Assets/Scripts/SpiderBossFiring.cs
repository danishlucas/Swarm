using UnityEngine;
using System.Collections;

public class SpiderBossFiring : MonoBehaviour {

    public GameObject bullet;
    public GameObject shotSpawn;
    public float shotDelay;
    public float repeatRate;
    public float shotSpeed;
    public GameObject Player;

    // Use this for initialization
    void Start () {
        InvokeRepeating("LaunchProjectile", shotDelay, repeatRate);
    }

    void LaunchProjectile()
    {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            float angle = Mathf.Atan2(Player.transform.position.y - transform.position.y,
                                           Player.transform.position.x - transform.position.x);
            GameObject instance = Instantiate(bullet, shotSpawn.transform.position, shotSpawn.transform.rotation) as GameObject;
            Rigidbody2D rb2 = instance.GetComponent<Rigidbody2D>(); // rb2 is for the bullets
            rb2.velocity = new Vector2(Mathf.Cos(angle) * shotSpeed, Mathf.Sin(angle) * shotSpeed);
        }
    }
}
