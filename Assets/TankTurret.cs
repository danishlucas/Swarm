using UnityEngine;
using System.Collections;

public class TankTurret : MonoBehaviour {
    private GameObject Player;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
        InvokeRepeating("rotatoPotato", 0, .05f);
    }

     void rotatoPotato()
     {
        if (this.GetComponent<EnemyAttributes>().room.GetComponent<PlayerInRoom>().InRoom)
        {
            transform.LookAt(Player.transform.position);
    transform.Rotate(new Vector3(0,-90, 90), Space.Self);//correcting the original rotation
            //transform.Rotate(new Vector3(0, -90, -90), Space.Self); // need to make y always rotato to 0!!!
         }
      }

    // Update is called once per frame h
    void Update () {
	
	}
}
