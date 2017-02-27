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
	}
	
	// Update is called once per frame
	void Update () {
        health = Player.GetComponent<Attributes>().health;
        HeartUI.sprite = HealthSprites[health];
	}
}
