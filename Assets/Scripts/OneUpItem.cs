using UnityEngine;
using System.Collections;

public class OneUpItem : MonoBehaviour {

    GameObject Player;
    Attributes stats;

    void Start()
    {
        Player = GameObject.Find("PLAYER");
        stats = Player.GetComponent<Attributes>(); 
    }

    void Update()
    {
        if (stats.health == stats.maxHealth)
        {
            gameObject.layer = 12;
        }
        else
        {
            gameObject.layer = 11;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {  
            Destroy(gameObject);
            stats.heal();    
        }
    }
}
