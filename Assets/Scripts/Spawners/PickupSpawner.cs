using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{

    public GameObject pickupPrefab;

    public float spawnDelay;

    private float nextSpawnTime;

    private Transform tf;

    private GameObject spawnedPickup;
    // Start is called before the first frame update
    void Start()
    {

        tf = transform;

        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedPickup == null)
        {

            if (Time.time > nextSpawnTime)
            {

                spawnedPickup = Instantiate(pickupPrefab, tf.position, Quaternion.identity);
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
