using UnityEngine;
using System.Collections;

public class SpeedUpItem : MonoBehaviour {

    private bool active;


    void Start()
    {
        active = false;
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

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerController>().moveForce < 5.5)
                other.GetComponent<PlayerController>().moveForce+=.5f;
            other.GetComponent<Attributes>().speedUpsGrabbed++;
            Destroy(gameObject);
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(1.25f);
        active = true;
    }


}

