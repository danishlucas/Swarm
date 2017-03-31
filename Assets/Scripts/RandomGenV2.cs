using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Roomtype with number
int onlyLeft = 1;
int onlyRight = 2;
int onlyUp = 3;
int onlyDown = 4;
int leftRight = 5;
int leftUp = 6;
int leftDown = 7;
int rightUp = 8;
int rightDown = 9;
int upDown = 10;
int leftUpRight = 11;
int leftDownRight = 12;
int upRightDown = 13;
int upLeftDown = 14;
int allSides = 0;
*/

public class RandomGenV2 : MonoBehaviour {

    //Variables
    public GameObject player; //Player
    public GameObject[] rooms; //List of Room Objects

    GameObject[,] typeMap = new GameObject[7, 7]; //Map of Determined Objects

    public List<Vector3> createdTiles;

    Vector3 center = new Vector3(3, 3); //Center
    public int roomCap; //Most Rooms in a floor

    public int vertTileOffset; //Vertical Distance between Rooms
    public int horzTileOffset; //Horizontal Distance between Rooms


    //Main Process
    void Start() {
        StartCoroutine(GenerateLevel()); //Builds Room Map
        //StartCoroutine(PlaceObjects()); //Generates Objects based on Room Map
    }

    //Builds Room Grid
    IEnumerator GenerateLevel(){

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
    void drawRooms(){
        for(int i = 0; i < 7; i++){
            for (int j = 0; j < 7; j++) {
                //Places Specified Room
                if (typeMap[i, j] != null){
                    GameObject type = typeMap[i, j];
                    placeRoom(type);
                }

                //Places Player Object in center
                if (i == 3 && j == 3){
                    placePlayer();
                }

                //Determines Move Direction
                if((j == 0 || j == 2 || j == 4 || j == 6) && (i != 6)){
                    MoveGen(1); //Move Right on Odd
                }else if(((j == 0 || j == 2 || j == 4 || j == 6) && (i == 6)) || ((j == 1 || j == 3 || j == 5) && (i == 0))){
                    MoveGen(2); //Move Down on Ends
                }else if((j == 1 || j == 3 || j == 5) && (i != 0)){
                    MoveGen(3); //Move Left on Even
                }
            }
        }

        //yield return null;
        //StopCoroutine(PlaceObjects());
    }

    void determineRoom(int xLoc, int yLoc){
        //Creates Copy of Roomtypes
        //ArrayList tempMap = new ArrayList();
        List<GameObject> tempMap = new List<GameObject>();
        List<GameObject> compMap = new List<GameObject>();
        for(int i = 0; i < rooms.Length; i++){
            tempMap.Add(rooms[i]);
            compMap.Add(rooms[i]);
        }

        GameObject toLeft = null;
        GameObject toRight = null;
        GameObject toUp = null;
        GameObject toDown = null;

        //Gets the rooms surrounding the targeted room
        if (xLoc > 1 && xLoc < 6 && yLoc > 1 && yLoc < 6)
        {
            toLeft = typeMap[xLoc - 1, yLoc];
        }
        if (xLoc < 6 && xLoc > 1 && yLoc > 1 && yLoc < 6)
        {
            toRight = typeMap[xLoc + 1, yLoc];
        }
        if(xLoc > 1 && xLoc < 6 && yLoc > 1 && yLoc < 6)
        {
            toUp = typeMap[xLoc, yLoc - 1];
        }
        if (yLoc < 6 && yLoc > 1 && xLoc > 1 && xLoc < 6)
        {
            toDown = typeMap[xLoc, yLoc + 1];
        }

        //If there is a room to the left, remove all rooms that dont have a door in that direction and replace with null
        if (toLeft != null && (toLeft == (rooms[0])) || (toLeft == (rooms[2])) || (toLeft == rooms[5]) || (toLeft == rooms[8]) || (toLeft == rooms[9]) || (toLeft == rooms[11]) || (toLeft == rooms[12]) || (toLeft == rooms[13])) {
            tempMap.RemoveAt(1);
            tempMap.Insert(1, null);
            tempMap.RemoveAt(3);
            tempMap.Insert(3, null);
            tempMap.RemoveAt(4);
            tempMap.Insert(4, null);
            tempMap.RemoveAt(6);
            tempMap.Insert(6, null);
            tempMap.RemoveAt(7);
            tempMap.Insert(7, null);
            tempMap.RemoveAt(10);
            tempMap.Insert(10, null);
            tempMap.RemoveAt(14);
            tempMap.Insert(14, null);
        }

        //If there is a room to the right, remove all rooms that dont have a door in that direction
        if (toRight != null && (toRight == rooms[0]) || (toRight == rooms[1]) || (toRight == rooms[5]) || (toRight == rooms[6]) || (toRight == rooms[7]) || (toRight == rooms[11]) || (toRight == rooms[12]) || (toLeft == rooms[14]))
        {
            tempMap.RemoveAt(13);
            tempMap.Insert(13, null);
            tempMap.RemoveAt(2);
            tempMap.Insert(2, null);
            tempMap.RemoveAt(3);
            tempMap.Insert(3, null);
            tempMap.RemoveAt(4);
            tempMap.Insert(4, null);
            tempMap.RemoveAt(8);
            tempMap.Insert(8, null);
            tempMap.RemoveAt(9);
            tempMap.Insert(9, null);
            tempMap.RemoveAt(10);
            tempMap.Insert(10, null);
        }

        //If there is a room to the top, remove all rooms that dont have a door in that direction
        if (toUp != null && (toUp == rooms[0]) || (toUp == rooms[3]) || (toUp == rooms[7]) || (toUp == rooms[9]) || (toUp == rooms[10]) || (toUp == rooms[12]) || (toUp == rooms[13]) || (toUp == rooms[14]))
        {
            tempMap.RemoveAt(1);
            tempMap.Insert(1, null);
            tempMap.RemoveAt(3);
            tempMap.Insert(3, null);
            tempMap.RemoveAt(2);
            tempMap.Insert(2, null);
            tempMap.RemoveAt(5);
            tempMap.Insert(5, null);
            tempMap.RemoveAt(7);
            tempMap.Insert(7, null);
            tempMap.RemoveAt(9);
            tempMap.Insert(9, null);
            tempMap.RemoveAt(12);
            tempMap.Insert(12, null);
        }

        //If there is a room to the bottom, remove all rooms that dont have a door in that direction
        if (toDown != null && (toDown == rooms[0]) || (toDown == rooms[4]) || (toDown == rooms[6]) || (toDown == rooms[8]) || (toDown == rooms[10]) || (toDown == rooms[11]) || (toDown == rooms[13]) || (toDown == rooms[14]))
        {
            tempMap.RemoveAt(1);
            tempMap.Insert(1, null);
            tempMap.RemoveAt(2);
            tempMap.Insert(2, null);
            tempMap.RemoveAt(4);
            tempMap.Insert(4, null);
            tempMap.RemoveAt(6);
            tempMap.Insert(6, null);
            tempMap.RemoveAt(5);
            tempMap.Insert(5, null);
            tempMap.RemoveAt(8);
            tempMap.Insert(8, null);
            tempMap.RemoveAt(11);
            tempMap.Insert(11, null);
        }

        //Removes all null room possibilities
        for(int k = tempMap.Count - 1; k >= 0; k--){
            if(tempMap[k] == null){
                tempMap.RemoveAt(k);
            }
        }

        //Chooses a random room of the possible
        int possibleRooms = tempMap.Count;
        GameObject finalRoom = (GameObject)tempMap[Random.Range(0, possibleRooms - 1)];
        if (yLoc < 6 && yLoc > 1 && xLoc > 1 && xLoc < 6)
        {
            typeMap[xLoc, yLoc] = finalRoom;
        }
        int finalRoomType = 0;

        roomCap--;

        //Find the index of the chosen roomtype
        for(int m = 0; m < compMap.Count - 1; m++){
            if (compMap[m] == (finalRoom)){
                finalRoomType = m;
            }
        }

        //If the chosen room has a door to the left, generate that room
        if((finalRoomType == 0 || finalRoomType == 1 || finalRoomType == 5 || finalRoomType == 6 || finalRoomType == 7 || finalRoomType == 11 || finalRoomType == 12 || finalRoomType == 14) && (toLeft == null)){
            if (roomCap > 0 && xLoc > 0)
            {
                determineRoom(xLoc - 1, yLoc);
            }
        }

        //If the chosen room has a door to the right, generate that room
        if ((finalRoomType == 0 || finalRoomType == 2 || finalRoomType == 5 || finalRoomType == 8 || finalRoomType == 9 || finalRoomType == 11 || finalRoomType == 12 || finalRoomType == 13) && (toRight == null))
        {
            if(roomCap > 0 && xLoc < 7) {
                determineRoom(xLoc + 1, yLoc);
            }
        }

        //If the chosen room has a door to the top, generate that room
        if ((finalRoomType == 0 || finalRoomType == 4 || finalRoomType == 6 || finalRoomType == 8 || finalRoomType == 10 || finalRoomType == 11 || finalRoomType == 13 || finalRoomType == 14) && (toUp == null))
        {
            if(roomCap > 0 && yLoc > 0) {
                determineRoom(xLoc, yLoc + 1);
            }
        }

        //If the chosen room has a door to the bottom, generate that room
        if ((finalRoomType == 0 || finalRoomType == 3 || finalRoomType == 7 || finalRoomType == 9 || finalRoomType == 10 || finalRoomType == 12 || finalRoomType == 13 || finalRoomType == 14) && (toDown == null))
        {
            if (roomCap > 0 && yLoc < 7)
            {
                determineRoom(xLoc, yLoc - 1);
            }
        }
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
    void placePlayer(){
        Instantiate(player, transform.position, Quaternion.identity);
    }

    //Generates Specified Roomtype GameObject
    void placeRoom(GameObject roomType){
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject = Instantiate(roomType, transform.position, transform.rotation) as GameObject;
            createdTiles.Add(tileObject.transform.position);
        }           
    }

}
