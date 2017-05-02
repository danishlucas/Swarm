using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PCAttributes : Attributes {

    public int health;
    public int maxHealth;
    GameObject Player;
    public bool invulnerable;
    public float invulnerabilityTime;
    public float sizeChange;
    public float speedUpsGrabbed;
    public float maxSpeed;
    public float theoreticalSpeed;
    public float actualSpeed;
    public float minSpeed;


    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        health = 6;
        maxHealth = 6;
        invulnerable = false;
        speedUpsGrabbed = 0;
        theoreticalSpeed = 3;
        actualSpeed = 3;
        minSpeed = 2.5f;

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
        maxSpeed = 5f + 0.5f * speedUpsGrabbed;
        minSpeed = 2.5f + 0.5f * speedUpsGrabbed;

    }
    // called when player takes damage
    public void takeDamage()
    {
        if (this.GetComponent<PCPlayerController>().isDashing == true || invulnerable == true)
        {
            Debug.Log("Ha we don't take damage get rekt");
        }
        else if (health != 0)
        {


            invulnerable = true;
            Invoke("StopInvul", invulnerabilityTime);
            health--;
            transform.localScale -= new Vector3(sizeChange, sizeChange, 0);
            Debug.Log("Damaged! health = " + health);
            if (health <= 0)
            {
                Debug.Log("Alas! I am slain!");
                Destroy(GameObject.Find("PLAYER"));
                SceneManager.LoadScene("DeathScene");
            }
            theoreticalSpeed += .5f;
            if (theoreticalSpeed <= maxSpeed && theoreticalSpeed >= minSpeed)
                actualSpeed = theoreticalSpeed;
            this.GetComponent<PCPlayerController>().moveForce = actualSpeed;

        }

    }

    public void heal()
    {
        if (health < maxHealth)
            health++;
        transform.localScale += new Vector3(sizeChange, sizeChange, 0);
        Debug.Log("healed! health = " + health);
        theoreticalSpeed -= .5f;
        if (theoreticalSpeed >= minSpeed && theoreticalSpeed <= maxSpeed)
            actualSpeed = theoreticalSpeed;
        this.GetComponent<PCPlayerController>().moveForce = actualSpeed;
    }

    void StopInvul()
    {
        invulnerable = false;
    }


}
