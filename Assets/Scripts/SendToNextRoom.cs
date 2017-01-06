using UnityEngine;


public class SendToNextRoom : MonoBehaviour
{


    public int dir; // 1 = north, 2 = east, 3 = south, 4 = west
    public int roomKey;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collision bro?");
            if (dir == 1)
            {
                Debug.Log("Norf");
                other.transform.Translate(0, 6f, 0);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(0, 11, 0);
            }
            if (dir == 2)
            {
                Debug.Log("I thought you said Weast");
                other.transform.Translate(4.5f, 0, 0);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(16, 0, 0);
            }
            if (dir == 3)
            {
                Debug.Log("Southernly");
                other.transform.Translate(0, -5, 0);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(0, -11, 0);
            }
            if (dir == 4)
            {
                Debug.Log("real west side");
                other.transform.Translate(-6, 0, 0);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(-16, 0, 0);
            }
        }
    }
}


