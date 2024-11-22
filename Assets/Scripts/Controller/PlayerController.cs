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
            pawn.noiseMaker.volumeDistance = pawn.movingVolumeDistance;
        }
        else
        {
            pawn.noiseMaker.volumeDistance = 0;
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
            pawn.noiseMaker.volumeDistance = pawn.movingVolumeDistance;
        }
        else
        {
            pawn.noiseMaker.volumeDistance = 0;
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
            pawn.noiseMaker.volumeDistance = pawn.movingVolumeDistance;
        }
        else
        {
            pawn.noiseMaker.volumeDistance = 0;
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
            pawn.noiseMaker.volumeDistance = pawn.movingVolumeDistance;
        }
        else
        {
            pawn.noiseMaker.volumeDistance = 0;
        }

        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }

        if (!Input.GetKey(moveForwardKey) && !Input.GetKey(moveBackwardKey) && !Input.GetKey(rotateClockwiseKey) && !Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.noiseMaker.volumeDistance = 0;
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
