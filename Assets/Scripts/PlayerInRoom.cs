using UnityEngine;
using System.Collections;

public class PlayerInRoom : MonoBehaviour {
    public bool InRoom = false;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InRoom = true;

        }
    }
}
