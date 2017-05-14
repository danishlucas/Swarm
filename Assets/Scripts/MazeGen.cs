using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeGen : MonoBehaviour {

    public int xSize; // gotta be odd!
    public int ySize; // gotta be odd!
    public byte[,] array;
    private bool bossRoomMade = false;
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
        List<int> neighbors = get0Neighbors(1, 1);
        if (neighbors.Count == 4)
        {
            GameObject instance = Instantiate(StartingRooms[1], transform.position, transform.rotation) as GameObject;
        }
        else if (neighbors.Count == 2 && neighbors[0] == 2)
        {
            GameObject instance = Instantiate(StartingRooms[2], transform.position, transform.rotation) as GameObject;
        }
        else if (neighbors.Count == 2 && neighbors[1] == 2)
        {
            GameObject instance = Instantiate(StartingRooms[3], transform.position, transform.rotation) as GameObject;
        }
        int currentCellX = 2;
        int currentCellY = 1;
        neighbors.Clear();
        // notes:
        // up = currentCellY - 1
        // left = currentCellX - 1
        // right = currentCellX + 1
        // down = currentCellY + 1
        while(currentCellY != ySize - 1)
        {
            while (currentCellX != xSize - 1)
            {
                if (array[currentCellX, currentCellY] == 0)
                {
                    transform.position = new Vector3(20 * (currentCellX - 1), -11 * (currentCellY - 1), 0);
                    neighbors = get0Neighbors(currentCellX, currentCellY);
                    if (neighbors.Count == 8)
                    {
                        int magicNumber = Random.Range(0, NESW.Count);
                        GameObject instance = Instantiate(NESW[magicNumber], transform.position, transform.rotation) as GameObject;
                    }
                    if (neighbors.Count == 6)
                    {
                        if (neighbors[1] == currentCellY - 1 && neighbors[2] == currentCellX - 1 && neighbors[4] == currentCellX + 1)
                        {
                            int magicNumber = Random.Range(0, NEW.Count);
                            GameObject instance = Instantiate(NEW[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                        if (neighbors[1] == currentCellY - 1 && neighbors[2] == currentCellX - 1 && neighbors[5] == currentCellY + 1)
                        {
                            int magicNumber = Random.Range(0, NSW.Count);
                            GameObject instance = Instantiate(NSW[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                        if (neighbors[1] == currentCellY - 1 && neighbors[2] == currentCellX + 1 && neighbors[5] == currentCellY + 1)
                        {
                            int magicNumber = Random.Range(0, NES.Count);
                            GameObject instance = Instantiate(NES[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                        if (neighbors[0] == currentCellX - 1 && neighbors[2] == currentCellX + 1 && neighbors[5] == currentCellY + 1)
                        {
                            int magicNumber = Random.Range(0, ESW.Count);
                            GameObject instance = Instantiate(ESW[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                    }
                    if (neighbors.Count == 4)
                    {
                        if (neighbors[1] == currentCellY - 1  && neighbors[2] == currentCellX + 1)
                        {
                            int magicNumber = Random.Range(0, NW.Count);
                            GameObject instance = Instantiate(NW[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                        if (neighbors[1] == currentCellY - 1 && neighbors[3] == currentCellY + 1)
                        {
                            int magicNumber = Random.Range(0, NS.Count);
                            GameObject instance = Instantiate(NS[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                        if (neighbors[1] == currentCellY - 1 && neighbors[2] == currentCellX - 1)
                        {
                            int magicNumber = Random.Range(0, NW.Count);
                            GameObject instance = Instantiate(NW[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                        if (neighbors[0] == currentCellX + 1 && neighbors[3] == currentCellY + 1)
                        {
                            int magicNumber = Random.Range(0, ES.Count);
                            GameObject instance = Instantiate(ES[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                        if (neighbors[0] == currentCellX - 1 && neighbors[2] == currentCellX + 1)
                        {
                            int magicNumber = Random.Range(0, EW.Count);
                            GameObject instance = Instantiate(EW[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                        if (neighbors[0] == currentCellX - 1 && neighbors[3] == currentCellY + 1)
                        {
                            int magicNumber = Random.Range(0, SW.Count);
                            GameObject instance = Instantiate(SW[magicNumber], transform.position, transform.rotation) as GameObject;
                        }

                    }
                    if (neighbors.Count == 2)
                    {
                        if (neighbors[1] == currentCellY - 1)
                        {
                            int magicNumber = Random.Range(0, N.Count);
                            GameObject instance = Instantiate(N[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                        if (neighbors[0] == currentCellX + 1)
                        {
                            if (!bossRoomMade)
                            {
                                GameObject instance = Instantiate(E[1], transform.position, transform.rotation) as GameObject;
                                bossRoomMade = true;
                            }
                            else
                            {
                                //int magicNumber = Random.Range(0, E.Count);
                                GameObject instance = Instantiate(E[0], transform.position, transform.rotation) as GameObject;
                            }
                        }
                        if (neighbors[0] == currentCellX - 1)
                        {
                            if (!bossRoomMade)
                            {
                                GameObject instance = Instantiate(W[1], transform.position, transform.rotation) as GameObject;
                                bossRoomMade = true;
                            }
                            else
                            {
                                //int magicNumber = Random.Range(0, E.Count);
                                GameObject instance = Instantiate(W[0], transform.position, transform.rotation) as GameObject;
                            }
                        }
                        if (neighbors[1] == currentCellY + 1)
                        {
                            int magicNumber = Random.Range(0, S.Count);
                            GameObject instance = Instantiate(S[magicNumber], transform.position, transform.rotation) as GameObject;
                        }
                    }
                }
                neighbors.Clear();
                currentCellX++;
            }
            currentCellY++;
            currentCellX = 1;
            Debug.Log("Dora would be proud; we did it");
        }



                // yoyoyoyoyoyoyooyoyoyy so all the room prefabs are off by a certain distance in the rooms in UsableFloor, 
                // but if we say heck off then we can use that offset to our advantage
                // sike we'll just fix them


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

    //order: top, left, right, bottom
    public List<int> get0Neighbors(int x, int y)
    {
        List<int> list = new List<int>();
        if (y != 0 && array[x, y - 1] == 0)
        {
            list.Add(x);
            list.Add(y - 1);
        }
        if (x != 0 && array[x - 1, y] == 0)
        {
            list.Add(x - 1);
            list.Add(y);
        }
        if (x != xSize && array[x + 1, y] == 0)
        {
            list.Add(x + 1);
            list.Add(y);
        }
        if (y != ySize && array[x, y + 1] == 0)
        {
            list.Add(x);
            list.Add(y + 1);
        }
        Debug.Log(x + " " + y + " " + list.Count);
        foreach(int i in list)
        {
            Debug.Log(i);
        }
        return list;
    }
   





    
}
