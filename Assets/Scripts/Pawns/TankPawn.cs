using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    private float nextEventTime;
    // Start is called before the first frame update
    public override void Start()
    {
        nextEventTime = Time.time + fireRate;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    // method for calling move funct and passing in the value same goes for the rest of the respective functions in their own way 
    public override void MoveBackward()
    {
        Debug.Log("Moving Backward");
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void MoveForward() 
    {
        Debug.Log("Moving Forward");
        mover.Move(transform.forward, moveSpeed);
    }

    public override void RotateClockwise() 
    {
        Debug.Log("Rotating Clockwise");
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        Debug.Log("Rotating Counterclockwise");
        mover.Rotate(-turnSpeed);
    }


    // method to call Shoot funct with a set firerate 
    public override void Shoot()
    {
        Debug.Log("Fireing");
        if (Time.time >= nextEventTime)
        {
            // passing in all var needed for function
            shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
            // fire rate
            nextEventTime = Time.time + 1 / fireRate;
        }

    }
}
