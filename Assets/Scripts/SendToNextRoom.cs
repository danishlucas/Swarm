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
            /*
            Rigidbody2D rb2 = other.GetComponent<Rigidbody2D>();
            rb2.velocity = new Vector2(0, 0);
            */
            Debug.Log("Collision bro?");
            if (dir == 1)
            {
                Debug.Log("Norf");
                other.transform.Translate(Vector2.up * 3.5f, Camera.main.transform);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(0, 11, 0);
            }
            if (dir == 2)
            {
                Debug.Log("I thought you said Weast");
                other.transform.Translate(Vector2.right * 3.5f, Camera.main.transform);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(16, 0, 0);
            }
            if (dir == 3)
            {
                Debug.Log("Southernly");
                other.transform.Translate(Vector2.down * 3.5f, Camera.main.transform);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(0, -11, 0);
            }
            if (dir == 4)
            {
                Debug.Log("real west side");

                other.transform.Translate(Vector2.left * 3.5f, Camera.main.transform);
                var cam = GameObject.Find("Main Camera");
                cam.transform.Translate(-16, 0, 0);
            }
        }
    }
}


