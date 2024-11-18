using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // movment speed variable
    public float moveSpeed;

    // turn speed variable
    public float turnSpeed;

    // mover var
    public Mover mover;

    // var for shooter
    public Shooter shooter;

    // var to hold the shellPrefab
    public GameObject shellPrefab;

    // holds the force behind the shots from cannon
    public float fireForce;

    // var to hold the damage a shot does.
    public float damageDone;

    // var to hold the lifespan of a shell
    public float shellLifespan;

    // var holing the rate of fire 
    public float fireRate;
   

    // Start is called before the first frame update
    public virtual void Start()
    {
        // intitalizing mover component and shooter component
        mover = GetComponent<Mover>();

        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    
    // methods for movment and fireing
    public abstract void MoveForward();

    public abstract void MoveBackward();

    public abstract void RotateClockwise();

    public abstract void RotateCounterClockwise();

    public abstract void Shoot();

}
