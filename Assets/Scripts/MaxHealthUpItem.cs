using UnityEngine;
using System.Collections;

public class MaxHealthUpItem : MonoBehaviour
{
    Attributes stats;
    GameObject Player;
    private bool active;
    void Start()
    {
        active = false;
        Player = GameObject.Find("PLAYER");
        if (Player == null)
            Player = GameObject.Find("PCPLAYER");
        stats = Player.GetComponent<Attributes>();
        if (stats == null)
            stats = Player.GetComponent<PCAttributes>();
        StartCoroutine("Activate");
    }

    void Update()
    {
        if (!active)
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
            
            stats.maxHealth++;
            stats.heal();
            Debug.Log("Max health.... UP!");

        }

    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(1.25f);
        active = true;
    }

}