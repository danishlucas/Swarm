using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

    public GameObject player;

    public GameObject[]rooms;

    public GameObject door;

    //public GameObject[] tiles;
    //public GameObject[] enemies;
    //public GameObject wall;

    public List<Vector3> createdTiles;

    public int tileAmount;
    public int vertTileOffset;
    public int horzTileOffset;

    public int enemyNumber;

    public float waitTime;

    //Starts the Level
    void Start () {
        StartCoroutine(GenerateLevel());
    }
	
    //Generates the level in random directions
    IEnumerator GenerateLevel()
    {
        for(int i = 0; i < tileAmount; i++)
        {
            
            int dir = Random.Range(0, 3);
            int floor = 0;
            int first = 0;
            int second = 1;
            int enemNum = enemyNumber;

            //Generates the floor
            createTile(floor, first, second, enemNum);

            bool inRoom = true;
            while (inRoom && i > 0)
            {
                if (door)
                {
                    inRoom = false;
                }
            }
            MoveGen(dir);

            //Waits to move generator between rooms
            yield return new WaitForSeconds(waitTime);

            if(i == 0)
            {
                internalGeneration();
            }
        }
        yield return 0;
    }

    //Moves the map generator
    void MoveGen(int dir)
    {
        //Moves generator in a random direction
        switch (dir)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y + vertTileOffset, 0);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x + horzTileOffset, transform.position.y, 0);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y - vertTileOffset, 0);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x - horzTileOffset, transform.position.y, 0);
                break;
        }
    }
    
    //Creates the Tiles as GameObjects and places on field
    void createTile(int floor, int first, int second, int enemyNum)
    {
        //Avoid overlapping
        if (!createdTiles.Contains(transform.position))
        {

            //Creates the first Strafer enemy in each room
//            GameObject firstEnemyObject;
//            firstEnemyObject = Instantiate(enemies[first], transform.position, transform.rotation) as GameObject;
//            createdTiles.Add(firstEnemyObject.transform.position);

            
            //Creates a second Strafer enemy in each room
//            GameObject firstCopyEnemyObject;
//            firstCopyEnemyObject = Instantiate(enemies[first], transform.position, transform.rotation) as GameObject;
//            createdTiles.Add(firstCopyEnemyObject.transform.position);

            //Creates an Omniturret enemy in the center of the room
//            GameObject secondEnemyObject;
//            secondEnemyObject = Instantiate(enemies[second], transform.position, transform.rotation) as GameObject;
//            createdTiles.Add(secondEnemyObject.transform.position);
            
            //Builds the floor plan
           GameObject tileObject;
            tileObject = Instantiate(rooms[floor], transform.position, transform.rotation) as GameObject;
            createdTiles.Add(tileObject.transform.position);

            //for(int i = 0; i < 4; i++)
            //{
            //    if (createdTiles.Contains())
            //    {

            //    }
            //}
            //GameObject doors;
            //    if(createdTiles.Contains(transform.position)
            //tileObject = Instantiate(tiles[door], )
        }
        //Adds an additional necessary room to the 
        else
        {
            tileAmount++;
        }
    }

    void internalGeneration()
    {
        Instantiate(player, createdTiles[Random.Range(0, createdTiles.Count)], Quaternion.identity);
        //for(int i = 0; i < createdTiles.Count; i++)
        //{

        //}
    }
}
