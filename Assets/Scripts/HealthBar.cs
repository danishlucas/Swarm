using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int health = GameObject.FindWithTag("Player").GetComponent<Attributes>().health;
        this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, health * 20);
    }
}
