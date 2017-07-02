using UnityEngine;
using System.Collections;

public class OneUpItem : MonoBehaviour {

    GameObject Player;
    Attributes stats;
    bool active;
    int done;

    void Start()
    {
        Player = GameObject.Find("PLAYER");
        if (Player == null)
            Player = GameObject.Find("PCPLAYER");
        stats = Player.GetComponent<Attributes>();
        if (stats == null)
            stats = Player.GetComponent<PCAttributes>();
        active = false;
        StartCoroutine("Activate");
        done = 0;
        
    }

    void Update()
    {
        if (stats.health == stats.maxHealth || !active)
        {
            gameObject.layer = 12;
        }
        else
        {
            gameObject.layer = 11;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && done == 0)
        {
            done++;
            Destroy(gameObject);
            stats.heal();    
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(1.25f);
        active = true;
    }
}
