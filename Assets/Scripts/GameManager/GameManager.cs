using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // var for storing the instance
    public static GameManager Instance;

    // vars for storing the two needed prefabs
    public GameObject playerControllerPrefab;
    public GameObject TankPawnPreFab;

    // var for holding player spawn.
    public Transform playerSpawnTransform;

    // listing player controllers
    public List<PlayerController> players = new List<PlayerController>();

    public void Awake()
    {
        // if statment for if no instance exists
        if (Instance == null)
        {
            Instance = this;

            // preventing object from being destroyed on new instance load
            DontDestroyOnLoad(gameObject);
        }

        // destroys the gamemanager spawned if instance has one
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        //spawn player at center of world along with a pawn that is connected to the controller
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newPawnObj = Instantiate(TankPawnPreFab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        // getting player controller and pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newController.pawn = newPawn;
    }
}

