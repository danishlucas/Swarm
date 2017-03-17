using UnityEngine;
using System.Collections;

public class MaxHealthUpItem : MonoBehaviour
{

    GameObject Player;
    private bool active;
    void Start()
    {
        active = false;
        Player = GameObject.Find("Player");
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
            Attributes stats = other.GetComponent<Attributes>();
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