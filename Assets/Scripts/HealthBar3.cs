using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar3 : MonoBehaviour
{

    public Sprite[] HealthSprites;
    public Image HeartUI;
    private GameObject Player;
    int health;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("PLAYER");
    }

    // Update is called once per frame
    void Update()
    {
        health = Player.GetComponent<Attributes>().health;
        int maxHealth = Player.GetComponent<Attributes>().maxHealth;
        if ( maxHealth == 9 && health == 9) { HeartUI.sprite = HealthSprites[3]; }
        else if (maxHealth == 9 && health == 8) { HeartUI.sprite = HealthSprites[2]; }
        else if (maxHealth == 9 && health == 7) { HeartUI.sprite = HealthSprites[1]; }
        else if (maxHealth == 6) { HeartUI.sprite = HealthSprites[0]; }
        else if (maxHealth == 8 && health == 8) { HeartUI.sprite = HealthSprites[8]; }
        else if (maxHealth == 8 && health == 7) { HeartUI.sprite = HealthSprites[5]; }
        else if (maxHealth == 8 && health <= 6) { HeartUI.sprite = HealthSprites[6]; }
        else if (maxHealth == 7 && health == 7) { HeartUI.sprite = HealthSprites[9]; }
        else if (maxHealth == 7 && health <= 6) { HeartUI.sprite = HealthSprites[7]; }
        else { HeartUI.sprite = HealthSprites[4]; }
    }
}
