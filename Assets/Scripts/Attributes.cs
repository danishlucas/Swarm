using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Attributes : MonoBehaviour {

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
    public float pointsMult;


    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        health = 6;
        maxHealth = 6;
        invulnerable = false;
        speedUpsGrabbed = 0;
        theoreticalSpeed = 3;
        actualSpeed = 3;
        minSpeed = 2.5f;
        pointsMult = 1;

    }
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this);
        maxSpeed = 5f + 0.5f * speedUpsGrabbed;
        minSpeed = 2.5f + 0.5f * speedUpsGrabbed;
        
	}
    // called when player takes damage
    public void takeDamage()
    {
        if (this.GetComponent<PlayerController>().isDashing == true || invulnerable == true)
        {
            Debug.Log("Ha we don't take damage get rekt");
        }
        else if (health != 0)
        {

            
            invulnerable = true;
            Invoke("StopInvul", invulnerabilityTime);
            health--;
            StartCoroutine("Damblage");
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
            this.GetComponent<PlayerController>().moveForce = actualSpeed;

        }

    }

    public void heal()
    {
        if (health < maxHealth)
        health++;
        transform.localScale += new Vector3 (sizeChange, sizeChange, 0);
        Debug.Log("healed! health = " + health);
        theoreticalSpeed -= .5f;
        if (theoreticalSpeed >= minSpeed && theoreticalSpeed <= maxSpeed)
            actualSpeed = theoreticalSpeed;
            this.GetComponent<PlayerController>().moveForce = actualSpeed;
    }

    void StopInvul()
    {
        invulnerable = false;
    }

    public void increasePointsMult()
    {
        pointsMult += .5f;
        StartCoroutine("EndPointsMult");
    }

    IEnumerator EndPointsMult()
    {
        yield return new WaitForSeconds(32.5f);
        pointsMult -= 0.5f;
    }

    IEnumerator Damblage()
    {
        Renderer renderer = GetComponent<Renderer>();
        for (var n = 0; n < 5; n++)
        {
            renderer.enabled = true;
            yield return new WaitForSeconds(.05f);
            renderer.enabled = false;
            yield return new WaitForSeconds(.05f);
        }
        renderer.enabled = true;
    }
}
