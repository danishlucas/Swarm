using UnityEngine;
using System.Collections;

public class SpeedUpItem : MonoBehaviour {

    GameObject Player;
    private bool active;
    public Attributes attributes;


    void Start()
    {
        Player = GameObject.Find("PLAYER");
        if (Player == null)
            Player = GameObject.Find("PCPLAYER");
        attributes = Player.GetComponent<Attributes>();
        if (attributes == null)
            attributes = Player.GetComponent<PCAttributes>();
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

            
            attributes.speedUpsGrabbed++;
            attributes.theoreticalSpeed += .5f;
            Debug.Log("theoretical speed up!");
            if (attributes.theoreticalSpeed <= attributes.maxSpeed && attributes.theoreticalSpeed >= attributes.minSpeed)
                attributes.actualSpeed = attributes.theoreticalSpeed;
            Debug.Log("speed up grabbed, " + attributes.actualSpeed);
            other.GetComponent<PlayerController>().moveForce = attributes.actualSpeed;

            Destroy(gameObject);
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(1.25f);
        active = true;
    }


}

