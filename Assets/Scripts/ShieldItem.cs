using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldItem : MonoBehaviour {

    GameObject Player;
    Attributes stats;
    bool active;
    bool done;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("PLAYER");
        stats = Player.GetComponent<Attributes>();
        active = false;
        done = true;
        StartCoroutine("Activate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Ping");
        if (other.gameObject.CompareTag("Player") && done)
        {
            Debug.Log("Pong");
            done = false;
            Destroy(gameObject);
            stats.shielded = true;
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(1.25f);
        active = true;
    }
}
