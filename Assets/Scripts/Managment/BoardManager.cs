using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.


public class BoardManager : MonoBehaviour
{

    //Sets Variable Objects
    private GameObject boardHolder; // GameObject that acts as a container for all other tiles.
    public GameObject player; //Player Object
    public int vertTileOffset; //Vertical Distance between Rooms
    public int horzTileOffset; //Horizontal Distance between Rooms


    //Level Status 
    public IntRange numRooms = new IntRange(8, 12); // The range of the number of rooms there can be.
    private int level = 0; //Current Level being Generated
    public int mapSize = 5; //Maximum sidelength of grid


    //Series of Different Room Types and their Prefabs
    public GameObject[] NRoom; //Type 0
    public GameObject[] ERoom; //Type 1
    public GameObject[] SRoom; //Type 2
    public GameObject[] WRoom; //Type 3
    public GameObject[] NERoom; //Type 4
    public GameObject[] NSRoom; //Type 5
    public GameObject[] NWRoom; //Type 6
    public GameObject[] ESRoom; //Type 7
    public GameObject[] EWRoom; //Type 8
    public GameObject[] SWRoom; //Type 9
    public GameObject[] NESRoom; //Type 10
    public GameObject[] NEWRoom; //Type 11
    public GameObject[] NSWRoom; //Type 12
    public GameObject[] ESWRoom; //Type 13
    public GameObject[] NESWRoom; //Type 14
    public GameObject[] DeadEnd; //Treasure Rooms


    //Sets Up different arrays of information
    int[,] typeMap = new int[5, 5]; //Map of Determined Room Type Numbers
    GameObject[,] roomMap = new GameObject[5, 5]; //Map of Determined Room Prefab Objects
    public List<Vector3> createdTiles; //List of Room Locations on grid


    //Private variables for simple step program
    private bool up = false;
    private bool right = false;
    private bool down = false;
    private bool left = false;
    private GameObject simpleRoom = null;
    public int tileAmount;
    private bool setUp = false;
    private bool setRight = false;
    private bool setDown = false;
    private bool setLeft = false;



    //Method Call to set up level generation
    internal void SetupScene(int currentLevel)
    {
        this.level = currentLevel;
        Start();
    }


    //Main method to process all level generation
    private void Start()
    {

        boardHolder = new GameObject("BoardHolder"); // Create the board holder
        //SetupTilesArray(); //Generates array of random objects
        simpleStep();
        placePlayer(); //Instantiates Player and Center Room
        //InstantiateFromArray(roomMap); //Instantiates the remaining rooms

    }


    //Simple GameObject that steps around and builds level
    void simpleStep()
    {
        for (int i = 0; i < tileAmount; i++)
        {
            int dir = decideType();
            fillRooms(up, right, down, left);
            moveGen(dir);
        }
    }


    int decideType() //Sets room number and random direction to continue stepping
    {
        IntRange doorType = new IntRange(0, 14);
        int randType = doorType.Random;
        int movDir = 0;

        IntRange fourTest = new IntRange(0, 3);
        IntRange threeTest = new IntRange(0, 2);
        IntRange twoTest = new IntRange(0, 1);


        if (randType == 0) //Tests North
        {
            IntRange specRoom = new IntRange(0, NRoom.Length - 1);
            simpleRoom = NRoom[specRoom.Random];
            movDir = 0;
        }
        if (randType == 1) //Tests East
        {
            IntRange specRoom = new IntRange(0, ERoom.Length - 1);
            simpleRoom = ERoom[specRoom.Random];
            movDir = 1;
        }
        if (randType == 2) //Tests South
        {
            IntRange specRoom = new IntRange(0, SRoom.Length - 1);
            simpleRoom = SRoom[specRoom.Random];
            movDir = 2;
        }
        if (randType == 3) //Tests West
        {
            IntRange specRoom = new IntRange(0, WRoom.Length - 1);
            simpleRoom = WRoom[specRoom.Random];
            movDir = 3;
        }
        if (randType == 4) //Tests North East
        {
            IntRange specRoom = new IntRange(0, NERoom.Length - 1);
            simpleRoom = NERoom[specRoom.Random];

            int chooseMove = twoTest.Random;
            if(chooseMove == 1)
            {
                movDir = 1;
                setUp = true;
            }
            else
            {
                movDir = 0;
                setRight = true;
            }
        }
        if (randType == 5)
        {
            IntRange specRoom = new IntRange(0, NSRoom.Length - 1);
            simpleRoom = NSRoom[specRoom.Random];
            int chooseMove = twoTest.Random;
            if (chooseMove == 1)
            {
                movDir = 2;
                setUp = true;
            }
            else
            {
                movDir = 0;
                setDown = true;
            }
        }
        if (randType == 6)
        {
            IntRange specRoom = new IntRange(0, NWRoom.Length - 1);
            simpleRoom = NWRoom[specRoom.Random];
            int chooseMove = twoTest.Random;
            if (chooseMove == 1)
            {
                movDir = 3;
                setUp = true;
            }
            else
            {
                movDir = 0;
                setLeft = true;
            }
        }
        if (randType == 7)
        {
            IntRange specRoom = new IntRange(0, ESRoom.Length - 1);
            simpleRoom = ESRoom[specRoom.Random];
            int chooseMove = twoTest.Random;
            if (chooseMove == 1)
            {
                movDir = 2;
                setRight = true;
            }
            else
            {
                movDir = 1;
                setDown = true;
            }
        }
        if (randType == 8)
        {
            IntRange specRoom = new IntRange(0, EWRoom.Length - 1);
            simpleRoom = EWRoom[specRoom.Random];
            int chooseMove = twoTest.Random;
            if (chooseMove == 1)
            {
                movDir = 3;
                setRight = true;
            }
            else
            {
                movDir = 1;
                setLeft = true;
            }
        }
        if (randType == 9)
        {
            IntRange specRoom = new IntRange(0, SWRoom.Length - 1);
            simpleRoom = SWRoom[specRoom.Random];
            int chooseMove = twoTest.Random;
            if (chooseMove == 1)
            {
                movDir = 3;
                setDown = true;
            }
            else
            {
                movDir = 2;
                setLeft = true;
            }
        }
        if (randType == 10)
        {
            IntRange specRoom = new IntRange(0, NESRoom.Length - 1);
            simpleRoom = NESRoom[specRoom.Random];
            int chooseMove = threeTest.Random;
            if(chooseMove == 2)
            {
                movDir = 2;
                setUp = true;
                setRight = true;
            }
            else if(chooseMove == 1)
            {
                movDir = 1;
                setUp = true;
                setDown = true;
            }
            else
            {
                movDir = 0;
                setRight = true;
                setDown = true;
            }
        }
        if (randType == 11)
        {
            IntRange specRoom = new IntRange(0, NEWRoom.Length - 1);
            simpleRoom = NEWRoom[specRoom.Random];
            int chooseMove = threeTest.Random;
            if (chooseMove == 2)
            {
                movDir = 3;
                setUp = true;
                setRight = true;
            }
            else if (chooseMove == 1)
            {
                movDir = 1;
                setUp = true;
                setLeft = true;
            }
            else
            {
                movDir = 0;
                setRight = true;
                setLeft = true;
            }
        }
        if (randType == 12)
        {
            IntRange specRoom = new IntRange(0, NSWRoom.Length - 1);
            simpleRoom = NSWRoom[specRoom.Random];
            int chooseMove = threeTest.Random;
            if (chooseMove == 2)
            {
                movDir = 3;
                setDown = true;
                setUp = true;
            }
            else if (chooseMove == 1)
            {
                movDir = 2; 
                setUp = true;
                setLeft = true;
            }
            else
            {
                movDir = 0;
                setDown = true;
                setLeft = true;
            }
        }
        if (randType == 13)
        {
            IntRange specRoom = new IntRange(0, ESWRoom.Length - 1);
            simpleRoom = ESWRoom[specRoom.Random];
            int chooseMove = threeTest.Random;
            if (chooseMove == 2)
            {
                movDir = 3;
                setRight = true;
                setDown = true;
            }
            else if (chooseMove == 1)
            {
                movDir = 2;
                setRight = true;
                setLeft = true;
            }
            else
            {
                movDir = 1;
                setDown = true;
                setLeft = true;
            }
        }
        if (randType == 14)
        {
            IntRange specRoom = new IntRange(0, NESWRoom.Length - 1);
            simpleRoom = NESWRoom[specRoom.Random];
            int chooseMove = fourTest.Random;
            if(chooseMove == 3)
            {
                movDir = 3;
                setUp = true;
                setRight = true;
                setDown = true;
            }
            if (chooseMove == 2)
            {
                movDir = 2;
                setUp = true;
                setRight = true;
                setLeft = true;
            }
            else if (chooseMove == 1)
            {
                movDir = 1;
                setUp = true;
                setLeft = true;
                setDown = true;
            }
            else
            {
                movDir = 0;
                setLeft = true;
                setRight = true;
                setDown = true;
            }
        }

        return movDir;
    }

    void moveGen(int dir) //Moves in the direction specified
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

    void fillRooms(bool up, bool right, bool down, bool left)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject;
            tileObject = Instantiate(simpleRoom, transform.position, transform.rotation) as GameObject;
            createdTiles.Add(tileObject.transform.position);

            if (setUp)
            {
                GameObject deadEnd;
                Vector3 newLoc = new Vector3(transform.position.x, transform.position.y + vertTileOffset);
                deadEnd = Instantiate(DeadEnd[0], newLoc, transform.rotation) as GameObject;
                createdTiles.Add(deadEnd.transform.position);
            }
            if (setRight)
            {
                GameObject deadEnd;
                Vector3 newLoc = new Vector3(transform.position.x + horzTileOffset, transform.position.y);
                deadEnd = Instantiate(DeadEnd[1], newLoc, transform.rotation) as GameObject;
                createdTiles.Add(deadEnd.transform.position);
            }
            if (setDown)
            {
                GameObject deadEnd;
                Vector3 newLoc = new Vector3(transform.position.x, transform.position.y - vertTileOffset);
                deadEnd = Instantiate(DeadEnd[2], newLoc, transform.rotation) as GameObject;
                createdTiles.Add(deadEnd.transform.position);
            }
            if (setLeft)
            {
                GameObject deadEnd;
                Vector3 newLoc = new Vector3(transform.position.x - horzTileOffset, transform.position.y);
                deadEnd = Instantiate(DeadEnd[3], newLoc, transform.rotation) as GameObject;
                createdTiles.Add(deadEnd.transform.position);
            }
        }
        else{
            tileAmount++;
        }
    }


    //Randomly populates an array with room objects
    void SetupTilesArray()
    {

        int x, y;

        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                x = i + (mapSize/2);
                y = j + (mapSize/2);
                while (i > 0 || j > 0)
                {
                    selectRoom(x, y);
                    selectRoom(x, y - i * 2);
                    selectRoom(x - j * 2, y);
                    selectRoom(x - j * 2, y - i * 2);
                }
            }
        }
    }


    //Generates Level from array
    void InstantiateFromArray(GameObject[,] prefabs)
    {
        float xCoord, yCoord;
        // Create a random index for the array.
        int randomIndex = Random.Range(0, prefabs.Length);

        // The position to be instantiated at is based on the coordinates.
        //Vector3 position = new Vector3(xCoord, yCoord, 0f);

        // Create an instance of the prefab from the random index of the array.
        //GameObject tileInstance = Instantiate(prefabs[randomIndex], position, Quaternion.identity) as GameObject;

        // Set the tile's parent to the board holder.
        //tileInstance.transform.parent = boardHolder.transform;
    }


    //Generates Player Object and central room
    void placePlayer()
    {
        Vector3 center = new Vector3(133, -36, 0); //Specifies the center of the map
        Instantiate(player, center, Quaternion.identity); //Creates an instance of a player object in the center
        //Instantiate(NESWRoom[0], center, Quaternion.identity);
    }


    //Internal random room selection method
    void selectRoom(int xLoc, int yLoc)
    {
        int roomType = 0;
        GameObject leftRoom = null;
        GameObject rightRoom = null;
        GameObject upRoom = null;
        GameObject downRoom = null;

        if (xLoc > 0){
            if (roomMap[xLoc - 1, yLoc] != null)
            {
                leftRoom = roomMap[xLoc - 1, yLoc];
            }
        }
        if (yLoc > 0)
        {
            if (roomMap[xLoc, yLoc - 1] != null)
            {
                rightRoom = roomMap[xLoc, yLoc - 1];
            }
        }
        if (xLoc < mapSize)
        {
            if (roomMap[xLoc + 1, yLoc] != null)
            {
                downRoom = roomMap[xLoc + 1, yLoc];
            }
        }
        if (yLoc < mapSize)
        {
            if (roomMap[xLoc, yLoc + 1] != null)
            {
                upRoom = roomMap[xLoc, yLoc + 1];
            }
        }

        Boolean needLeft = false;
        Boolean needRight = false;
        Boolean needUp = false;
        Boolean needDown = false;

        if(rightRoom != null)
        {
            //Room to right has door pointing to left
            if (typeMap[xLoc + 1, yLoc] == 3 || typeMap[xLoc + 1, yLoc] == 6 || typeMap[xLoc + 1, yLoc] == 8 || typeMap[xLoc + 1, yLoc] == 9
                || typeMap[xLoc + 1, yLoc] == 11 || typeMap[xLoc + 1, yLoc] == 12 || typeMap[xLoc + 1, yLoc] == 13 || typeMap[xLoc + 1, yLoc] == 14)
            {
                needRight = true;
            }

        }

        if (leftRoom != null)
        {
            if (typeMap[xLoc - 1, yLoc] == 1 || typeMap[xLoc - 1, yLoc] == 4 || typeMap[xLoc - 1, yLoc] == 7 || typeMap[xLoc - 1, yLoc] == 8
                || typeMap[xLoc - 1, yLoc] == 10 || typeMap[xLoc - 1, yLoc] == 11 || typeMap[xLoc - 1, yLoc] == 13 || typeMap[xLoc - 1, yLoc] == 14)
            {
                needLeft = true;
            }
        }

        if (upRoom != null)
        {
            //Room to right has door pointing to left
            if (typeMap[xLoc, yLoc + 1] == 2 || typeMap[xLoc, yLoc + 1] == 5 || typeMap[xLoc, yLoc + 1] == 7 || typeMap[xLoc, yLoc + 1] == 9
                || typeMap[xLoc, yLoc + 1] == 10 || typeMap[xLoc, yLoc + 1] == 12 || typeMap[xLoc, yLoc + 1] == 13 || typeMap[xLoc, yLoc + 1] == 14)
            {
                needUp = true;
            }

        }

        if (downRoom != null)
        {
            //Room to right has door pointing to left
            if (typeMap[xLoc, yLoc - 1] == 0 || typeMap[xLoc, yLoc - 1] == 4 || typeMap[xLoc, yLoc - 1] == 5 || typeMap[xLoc, yLoc - 1] == 6
                || typeMap[xLoc, yLoc - 1] == 10 || typeMap[xLoc, yLoc - 1] == 11 || typeMap[xLoc, yLoc - 1] == 12 || typeMap[xLoc, yLoc - 1] == 14)
            {
                needDown = true;
            }

        }

        GameObject finalRandomRoom = null;

        // Setting Room Type from surrounding
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 14;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        else if (needRight && needDown && needLeft)
        {
            roomType = 13;
            IntRange temp = new IntRange(0, ESWRoom.Length);
            finalRandomRoom = ESWRoom[temp.Random];
        }
        else if (needUp && needDown && needLeft)
        {
            roomType = 12;
            IntRange temp = new IntRange(0, NSWRoom.Length);
            finalRandomRoom = NSWRoom[temp.Random];
        }
        else if (needUp && needRight && needLeft)
        {
            roomType = 11;
            IntRange temp = new IntRange(0, NEWRoom.Length);
            finalRandomRoom = NEWRoom[temp.Random];
        }
        else if (needUp && needRight && needDown)
        {
            roomType = 10;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 9;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 8;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 7;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 6;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 5;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 4;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 3;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 2;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 1;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }
        if (needUp && needRight && needDown && needLeft)
        {
            roomType = 0;
            IntRange temp = new IntRange(0, NRoom.Length);
            finalRandomRoom = NRoom[temp.Random];
        }



        else if (needUp && !needRight && !needDown && !needLeft)
        {
            roomType = 0;
        }
        else if (!needUp && needRight && !needDown && !needLeft)
        {
            roomType = 1;
        }
        else if (!needUp && !needRight && needDown && !needLeft)
        {
            roomType = 2;
        }
        else if (!needUp && !needRight && !needDown && needLeft)
        {
            roomType = 3;
        }
        else if (needUp && needRight && !needDown && !needLeft)
        {
            roomType = 4;
        }
        if (needUp && !needRight && needDown && !needLeft)
        {
            roomType = 5;
        }
        if (needUp && !needRight && !needDown && needLeft)
        {
            roomType = 6;
        }
        if (!needUp && needRight && needDown && !needLeft)
        {
            roomType = 7;
        }
        if (!needUp && needRight && !needDown && needLeft)
        {
            roomType = 8;
        }
        if (!needUp && !needRight && needDown && needLeft)
        {
            roomType = 9;
        }

        typeMap[xLoc, yLoc] = roomType;
        roomMap[xLoc, yLoc] = finalRandomRoom;

    }


    //Instantiates Specified Roomtype GameObject
    void placeRoom(GameObject roomType)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject = Instantiate(roomType, transform.position, transform.rotation) as GameObject;
            createdTiles.Add(tileObject.transform.position);
        }
    }

}
