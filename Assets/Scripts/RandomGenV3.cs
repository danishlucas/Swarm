using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomGenV3 : MonoBehaviour
{

    //Variables
    public GameObject player; //Player
    public GameObject[] rooms; //List of Room Objects

    GameObject[,] typeMap = new GameObject[7, 7]; //Map of Determined Objects

    public List<Vector3> createdTiles;

    public int roomCap; //Most Rooms in a floor
    public int vertTileOffset; //Vertical Distance between Rooms
    public int horzTileOffset; //Horizontal Distance between Rooms


    //Main Process
    void Start()
    {
        StartCoroutine(GenerateLevel()); //Builds Room Map
    }

    //Builds Room Grid
    IEnumerator GenerateLevel()
    {

        //Loop to set Random roomtype
        determineRoom(3, 3);

        if (roomCap == 0)
        {
            drawRooms();
        }

        yield return 0;
        //StopCoroutine(GenerateLevel());
    }

    //Places Corresponding Objects
    void drawRooms()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                //Places Specified Room
                if (typeMap[i, j] != null)
                {
                    GameObject type = typeMap[i, j];
                    placeRoom(type);
                }

                //Places Player Object in center
                if (i == 3 && j == 3)
                {
                    placePlayer();
                }

                //Determines Move Direction
                if ((j == 0 || j == 2 || j == 4 || j == 6) && (i != 6))
                {
                    MoveGen(1); //Move Right on Odd
                }
                else if (((j == 0 || j == 2 || j == 4 || j == 6) && (i == 6)) || ((j == 1 || j == 3 || j == 5) && (i == 0)))
                {
                    MoveGen(2); //Move Down on Ends
                }
                else if ((j == 1 || j == 3 || j == 5) && (i != 0))
                {
                    MoveGen(3); //Move Left on Even
                }
            }
        }

        //yield return null;
        //StopCoroutine(PlaceObjects());
    }

    void determineRoom(int xLoc, int yLoc)
    {
        
    }

    //Moves Generation Object
    void MoveGen(int dir)
    {
        //Moves generator in a specified direction
        switch (dir)
        {
            case 0: //Up  
                transform.position = new Vector3(transform.position.x, transform.position.y + vertTileOffset, 0);
                break;
            case 1: //Right
                transform.position = new Vector3(transform.position.x + horzTileOffset, transform.position.y, 0);
                break;
            case 2: //Down
                transform.position = new Vector3(transform.position.x, transform.position.y - vertTileOffset, 0);
                break;
            case 3: //Left
                transform.position = new Vector3(transform.position.x - horzTileOffset, transform.position.y, 0);
                break;
        }
    }

    //Generates Player Object
    void placePlayer()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }

    //Generates Specified Roomtype GameObject
    void placeRoom(GameObject roomType)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject = Instantiate(roomType, transform.position, transform.rotation) as GameObject;
            createdTiles.Add(tileObject.transform.position);
        }
    }

}
