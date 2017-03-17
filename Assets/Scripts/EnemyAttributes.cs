using UnityEngine;
using System.Collections;

public class EnemyAttributes : MonoBehaviour {
    public GameObject room;
    public float healthDropChance;
    public GameObject health;
    public GameObject Player;



    void Start()
    {
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
