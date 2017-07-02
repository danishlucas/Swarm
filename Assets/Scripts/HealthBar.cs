using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Sprite[] HealthSprites;
    public Image HeartUI;
    private GameObject Player;
    int health;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("PLAYER");
        if (Player == null)
            Player = GameObject.Find("PCPLAYER");
    }
	
	// Update is called once per frame
	void Update () {
        health = Player.GetComponent<Attributes>().health;
        if (health >= 3)
        {
            HeartUI.sprite = HealthSprites[3];
        }
        else if (health == 2)
        {
            HeartUI.sprite = HealthSprites[2];
        }
        else if (health == 1)
        {
            HeartUI.sprite = HealthSprites[1];
        }
        else
        {
            HeartUI.sprite = HealthSprites[0];
        }
    }
}
