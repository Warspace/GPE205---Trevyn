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

    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);
    }
    
    public override void Rotate(float turnspeed)
    {
        tf.Rotate(0, turnspeed * Time.deltaTime, 0);
    }
}

