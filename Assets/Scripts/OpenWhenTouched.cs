using UnityEngine;
using System.Collections;
using System;


public class OpenWhenTouched : MonoBehaviour
{

    public GameObject itemSpawn;
    public GameObject openedChest;
    int itemchosen;
   

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) { 
            GameObject itemChosen = GameObject.Find("ItemList").GetComponent<ItemList>().chooseRandoItem();
            
            
            GameObject item = Instantiate(itemChosen, itemSpawn.transform.position, itemSpawn.transform.rotation) as GameObject;
            GameObject chest = Instantiate(openedChest, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(gameObject);

        }
    }

}


