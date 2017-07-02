using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldUI : MonoBehaviour {

    public Sprite[] Images;
    public Image Shield;
    private GameObject Player;
    bool shielded;


	// Use this for initialization
	void Start () {
        Player = GameObject.Find("PLAYER");
        if (Player == null)
            Player = GameObject.Find("PCPLAYER");
    }
	
	// Update is called once per frame
	void Update () {
	    if (Player.GetComponent<Attributes>().shielded)
        {
            Shield.sprite = Images[1];
        } else
        {
            Shield.sprite = Images[0];
        }
	}
}
