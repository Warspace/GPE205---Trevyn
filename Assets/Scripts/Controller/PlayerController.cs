using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    // estabishing keys for movment 
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;

    // Start is called before the first frame update
    public override void Start()
    {
     
        if(GameManager.Instance != null)
        {
            if(GameManager.Instance.players !=null)
            {

               GameManager.Instance.players.Add(this);
            }
        }
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();
    }
    // method for creating said movements and fireing cannon
    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }

        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
    }

    public void OnDestroy()
    {
        // this chain is for if we have a game manager it will track the player and remove us from the list
        if (GameManager.Instance != null)
        {
            if(GameManager.Instance.players != null)
            {
               
                GameManager.Instance.players.Remove(this);
            }
        }
    }
}
