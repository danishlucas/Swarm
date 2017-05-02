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
        health = Player.GetComponent<PCAttributes>().health;
        if (health == 9)
        {
            HeartUI.sprite = HealthSprites[3];
        }
        else if (health == 8)
        {
            HeartUI.sprite = HealthSprites[2];
        }
        else if (health == 7)
        {
            HeartUI.sprite = HealthSprites[1];
        }
        else
        {
            HeartUI.sprite = HealthSprites[0];
        }
    }
}
