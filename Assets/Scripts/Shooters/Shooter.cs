using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void Start();


    // Update is called once per frame
    public abstract void Update();

    // public method to pass in shellPrefab its fireforce, damageDealt, and lifespan to main method.
    public abstract void Shoot(GameObject shellPrefab, float fireForce, float damageDealt, float lifespan);
}
