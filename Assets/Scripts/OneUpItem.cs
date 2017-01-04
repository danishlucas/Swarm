using UnityEngine;
using System.Collections;

public class OneUpItem : MonoBehaviour {

    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Attributes script = Player.GetComponent<Attributes>();
            script.health += 1;
            Player.gameObject.transform.localScale += new Vector3(.02f, .02f, 0);
        }

    }
}
