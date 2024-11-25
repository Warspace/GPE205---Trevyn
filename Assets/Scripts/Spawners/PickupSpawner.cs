using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    // container for holding given prefab
    public GameObject pickupPrefab;

    // pub float for holding spawn delay 
    public float spawnDelay;

    // pub float for holding next spawn time of powerup
    private float nextSpawnTime;

    // pub float for holding the pos of this object
    private Transform tf;

    // refrence for pickup if already spawned
    private GameObject spawnedPickup;
    // Start is called before the first frame update
    void Start()
    {
        // assigning transform
        tf = transform;

        // setting spawn time based of given times
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // check for if pickup is already spawned and if not goes to next if
        if (spawnedPickup == null)
        {

            // check for if enough time has passed for another spawn if so spawns another and resets delay
            if (Time.time > nextSpawnTime)
            {


                spawnedPickup = Instantiate(pickupPrefab, tf.position, Quaternion.identity);
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        // else for if ther is already a spawned powerup to reset the delay
        else
        {
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
