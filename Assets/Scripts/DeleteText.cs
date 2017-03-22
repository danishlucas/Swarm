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
            Destroy(welcome1);
            Destroy(welcome2);
            Destroy(welcome3);
        }
	
	}
}
