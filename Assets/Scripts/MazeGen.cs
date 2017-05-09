using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeGen : MonoBehaviour {

    public int xSize; // gotta be odd!
    public int ySize; // gotta be odd!
    public byte[,] array;
    public List<GameObject> StartingRooms = new List<GameObject>();
    public List<GameObject> N = new List<GameObject>();
    public List<GameObject> E = new List<GameObject>();
    public List<GameObject> S = new List<GameObject>();
    public List<GameObject> W = new List<GameObject>();
    public List<GameObject> NE = new List<GameObject>();
    public List<GameObject> NS = new List<GameObject>();
    public List<GameObject> NW = new List<GameObject>();
    public List<GameObject> ES = new List<GameObject>();
    public List<GameObject> EW = new List<GameObject>();
    public List<GameObject> SW = new List<GameObject>();
    public List<GameObject> NES = new List<GameObject>();
    public List<GameObject> NEW = new List<GameObject>();
    public List<GameObject> NSW = new List<GameObject>();
    public List<GameObject> ESW = new List<GameObject>();
    public List<GameObject> NESW = new List<GameObject>();





    // Use this for initialization
    void Start () {

        //phase 1
        array = new byte[xSize + 1, ySize + 1];
        if (xSize % 2 == 0)
            xSize++;
        if (ySize % 2 == 0)
            ySize++;

        //make everything a 1
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                array[i, j] = 1;
            }
        }

        //phase 2
        array[1, 1] = 0;
        List<int> listx = new List<int>();
        List<int> listy = new List<int>();
        List<int> neighborList = getNeighbors(1, 1);
        neighborList.Add(-99);
        while(neighborList[0] != -99)
        {
            listx.Add(neighborList[0]);
            neighborList.RemoveAt(0);
            listy.Add(neighborList[0]);
            neighborList.RemoveAt(0);
        }


        //phase 3
        while (listx.Count > 0)
        {
            int magicNumber = Random.Range(0, listx.Count);
            if (isValid(listx[magicNumber], listy[magicNumber])) {
                array[listx[magicNumber], listy[magicNumber]] = 0;
                neighborList = getNeighbors(listx[magicNumber], listy[magicNumber]);
                neighborList.Add(-99);
                while (neighborList[0] != -99)
                {
                    listx.Add(neighborList[0]);
                    neighborList.RemoveAt(0);
                    listy.Add(neighborList[0]);
                    neighborList.RemoveAt(0);
                }
            }
            listx.RemoveAt(magicNumber);
            listy.RemoveAt(magicNumber);
        }
        /*
        // just checkin
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                Debug.Log(i + " " + j + " " + array[i, j]);

            }
        }
        */

        buildMaze();

    }

    private void buildMaze()
    {

        // array[1,1] = 0;
        List<int> neighbors = getNeighbors(1, 1);
        if (neighbors.Count == 4)
        {
            GameObject instance = Instantiate(StartingRooms[1], transform.position, transform.rotation) as GameObject;
        }
        else if (neighbors.Count == 2 && neighbors[0] == 2)
        {
            GameObject instance = Instantiate(StartingRooms[1], transform.position, transform.rotation) as GameObject;
        }
        int currentCellX;
        int currentCellY;
    }



    private bool isValid(int x, int y)
    {
        
        if (array[x,y] == 0)
        {
            return false;
        }
        if (x % 2 == 0 && y % 2 == 0)
        {
            return false;
        }
        int count = 0;
        if (y != 0 && array[x, y - 1] == 1)
            count++;
        if (x != 0 && array[x - 1, y] == 1)
            count++;
        if (x != xSize - 1 && array[x + 1, y] == 1)
            count++;
        if (y != ySize - 1 && array[x, y + 1] == 1)
            count++;
        if (count < 3)
        {
            return false;
        }
        return true;

    }

    //order: top, left, right, bottom
    public List<int> getNeighbors(int x, int y) {
        List<int> list = new List<int>();
        if (isValid(x, y - 1))
        {
            list.Add(x);
            list.Add(y - 1);
        }
        if (isValid(x-1, y))
        {
            list.Add(x - 1);
            list.Add(y);
        }
        if (isValid(x + 1, y))
        {
            list.Add(x + 1);
            list.Add(y);
        } 
        if (isValid(x, y + 1))
        {
            list.Add(x);
            list.Add(y + 1);
        }
        return list;
    }

    public List<int> get0Neighbors(int x, int y)
    {
        List<int> list = new List<int>();
        if (array[x, y - 1] == 0)
        {
            list.Add(x);
            list.Add(y - 1);
        }
        if (array[x - 1, y] == 0)
        {
            list.Add(x - 1);
            list.Add(y);
        }
        if (isValid(x + 1, y))
        {
            list.Add(x + 1);
            list.Add(y);
        }
        if (isValid(x, y + 1))
        {
            list.Add(x);
            list.Add(y + 1);
        }
        return list;
    }
   





    
}
