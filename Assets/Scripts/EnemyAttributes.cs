using UnityEngine;
using System.Collections;

public class EnemyAttributes : MonoBehaviour {
    public GameObject room;
    public float healthDropChance;
    public GameObject health;
    public GameObject Player;
    private EnemyStats stats;
    //use this now


    void Start()
    {
        stats = GameObject.Find("EnemyStats").GetComponent<EnemyStats>();
        if (this.GetComponent<EnemyFiringAI>() != null)
        {
            healthDropChance = stats.straferDrop;

        }
        else if (this.GetComponent<OmniTurretAI>() != null)
        {
            healthDropChance = stats.omniDrop;
        }
        else if (this.GetComponent<TankEnemyMovement>() != null)
        {
            healthDropChance = stats.tankDrop;
        }

        Player = GameObject.FindWithTag("Player");
        room = gameObject.transform.root.gameObject;
    }
    public void tryDropHealth()
    {
        int rando = Random.Range(0, 99);
        if (healthDropChance * 100 > rando )
        {
            GameObject instance = Instantiate(health, this.transform.position, Quaternion.identity) as GameObject;
        }
    }
}
