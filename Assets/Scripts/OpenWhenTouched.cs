using UnityEngine;
using System.Collections;
using System;
//using Boo.Lang;

public class OpenWhenTouched : MonoBehaviour
{

    public GameObject itemSpawn;
    public int itemchosen;
    //public List<GameObject> itemList;
   
    void start()
    {
       // itemList = new List<GameObject>();
        //itemList.Add(
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            // chooseItem;
        {
            //GameObject instance = Instantiate(bullet, itemSpawn.transform.position, itemSpawn.transform.rotation) as GameObject;
            Destroy(gameObject);





        }
    }
    void chooseItem()
    {

    }
}


