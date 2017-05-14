using UnityEngine;
using System.Collections;

public class DeleteText : MonoBehaviour {

    public GameObject welcome1;
    public GameObject welcome2;
    public GameObject welcome3;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<PlayerInRoom>().InRoom)
        {
            Destroy(GameObject.Find("WelcomeText1"));
            Destroy(GameObject.Find("WelcomeText2"));
            Destroy(GameObject.Find("WelcomeText3"));
        }
	
	}
}
