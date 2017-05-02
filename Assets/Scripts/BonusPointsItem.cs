using UnityEngine;
using System.Collections;

public class BonusPointsItem : MonoBehaviour {

    GameObject Player;
    Attributes stats;
    bool active;
    int done;

    void Start()
    {
        Player = GameObject.Find("PLAYER");
        stats = Player.GetComponent<Attributes>();
        active = false;
        StartCoroutine("Activate");
        done = 0;

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && done == 0)
        {
            done++;
            Destroy(gameObject);
            stats.increasePointsMult();
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(1.25f);
        active = true;
    }
}

