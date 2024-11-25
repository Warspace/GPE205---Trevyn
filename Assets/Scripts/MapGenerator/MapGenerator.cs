using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // public container for game object
    public GameObject[] gridPrefabs;

    // public ints for rows and collums
    public int rows;
    public int cols;

    // public floats for room width and hight
    public float roomWidth = 50.0f;
    public float roomHeigth = 50.0f;

    // public container for holding array of rooms
    private Room[,] grid;

    // public bools for currnet time, map and map seed
    public bool isMapSeed;
    public bool isCurrentTime;
    public bool isMapOfTheDay;

    //  public in for the map seed
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

    // making function to get one of the given room prefabs
    public GameObject RandomRoomPrefab() 
    {
        return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)]; 
    }

    // function for generation using given map rooms
    public void GenerateMap()
    {
        // if statment for if the map has a seed and selected to gen off that
        if (isMapSeed)
        {
            UnityEngine.Random.InitState(mapSeed);
        }

        // if statment for generation of map based of time of day
        if (isCurrentTime)
        {
            UnityEngine.Random.InitState(DateToInt(DateTime.Now));
        }

        // if statment for generation of map based on day
        if (isMapOfTheDay) 
        {
            UnityEngine.Random.InitState(DateToInt(DateTime.Now.Date));
        }

        // starting the random num gen based of date and time
        UnityEngine.Random.InitState(DateToInt(DateTime.Now));

        // making array for columns and rows
        grid = new Room[cols, rows];

        // for loop to go through each row in the grid
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            // for loop to go through each column in the current row
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                
                // finding the x and y position of the current room
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeigth * currentRow;

                // Create a new position vector for the current room
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                // Places a random room prefab at the calculated position
                GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity);

                // Set the room's parent to the current transform
                tempRoomObj.transform.parent = transform;

                // Renameing to make stuff easier to view
                tempRoomObj.name = "Room_" + currentCol + "," + currentRow;

                // Get the Room component from the room object
                Room tempRoom = tempRoomObj.GetComponent<Room>();

                // Assigning the Room to the corresponding position in the grid
                grid[currentCol, currentRow] = tempRoom;

                // Disable doors based on the row's position in the grid
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

                // Disable doors based on the column's position in the grid
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

    // Making a current DateTime into an integer 
    public int DateToInt(DateTime dateToUse)
    {
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }
}

