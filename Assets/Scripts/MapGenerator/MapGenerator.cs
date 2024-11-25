using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject[] gridPrefabs;
    public int rows;
    public int cols;
    public float roomWidth = 50.0f;
    public float roomHeigth = 50.0f;
    private Room[,] grid;

    public bool isMapSeed;
    public bool isCurrentTime;
    public bool isMapOfTheDay;

    public int mapSeed;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject RandomRoomPrefab() 
    {
        return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)]; 
    }

    public void GenerateMap()
    {
        if (isMapSeed)
        {
            UnityEngine.Random.InitState(mapSeed);
        }

        if (isCurrentTime)
        {
            UnityEngine.Random.InitState(DateToInt(DateTime.Now));
        }

        if (isMapOfTheDay) 
        {
            UnityEngine.Random.InitState(DateToInt(DateTime.Now.Date));
        }

        UnityEngine.Random.InitState(DateToInt(DateTime.Now));
        grid = new Room[cols, rows];

        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            for(int currentCol = 0; currentCol < cols; currentCol++)
            {

                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeigth * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity);

                tempRoomObj.transform.parent = transform;

                tempRoomObj.name = "Room_" + currentCol + "," + currentRow;

                Room tempRoom = tempRoomObj.GetComponent<Room>();

                grid[currentCol, currentRow] = tempRoom;

                if (currentRow == 0) 
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if (currentRow == rows - 1)
                {
                    tempRoom.doorSouth.SetActive(false);
                }
                else
                {
                    tempRoom.doorNorth.SetActive(false);
                    tempRoom.doorSouth.SetActive(false);
                }

                if (currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == cols - 1)
                {
                    tempRoom.doorWest.SetActive(false);
                }
                else
                {
                    tempRoom.doorEast.SetActive(false);
                    tempRoom.doorWest.SetActive(false);
                }
            }
        }
    }
    public int DateToInt(DateTime dateToUse)
    {
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }
}

