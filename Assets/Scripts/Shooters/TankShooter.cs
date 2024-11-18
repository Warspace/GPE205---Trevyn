using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    // public var to hold the fire point of the shell
    public Transform firepointTransform;

    public override void Start()
    {

    }


    public override void Update()
    {

    }


    public override void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float lifespan)
    {
        // creates new shell at firepoint
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;
        
        // calling the damage on hit function
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();

        // assigning damage of fired shells
        if (doh !=null)
        {
            doh.damageDone = damageDone;

            doh.owner = GetComponent<Pawn>();
        }

        Rigidbody rb = newShell.GetComponent<Rigidbody>();

        // assigns force on the shell
        if (rb != null)
        {
            rb.AddForce(firepointTransform.forward * fireForce); 
        }

        // removes the shell from the play space
        Destroy(newShell, lifespan);
    }
}
