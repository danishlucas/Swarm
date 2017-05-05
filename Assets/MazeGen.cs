using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeGen : MonoBehaviour {

    public int xSize; // gotta be odd!
    public int ySize; // gotta be odd!
    byte[,] array;


	// Use this for initialization
	void Start () {

        //phase 1
        array = new byte[xSize, ySize];
        if (xSize % 2 == 0)
            xSize++;
        if (ySize % 2 == 0)
            ySize++;

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
        listx.
        while (listx)


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
        if (x != xSize && array[x + 1, y] == 1)
            count++;
        if (y != ySize && array[x, y + 1] == 1)
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




    
}
