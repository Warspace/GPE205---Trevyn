using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    // Variable to hold the Rigidbody Component
    private Rigidbody rb;

    private Transform tf;

    // Start is called before the first frame update
    public override void Start()
    {
        // initializing components
        rb = GetComponent<Rigidbody>();

        tf = transform;
    }

    void Update()
    {

    }

    // uses given speed to move in a given direction
    public override void Move(Vector3 direction, float speed)
    {
        // normalization to make motions fluid when changing directions
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;

        // actualy updating the position
        rb.MovePosition(rb.position + moveVector);
    }
    
    // rotating given the supplied turn speed
    public override void Rotate(float turnspeed)
    {
        // applying the rotation to the object in the game space
        tf.Rotate(0, turnspeed * Time.deltaTime, 0);
    }
}

