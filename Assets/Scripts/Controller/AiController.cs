using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : Controller
{
    // defining possible Ai states
    public enum AIState { Guard, Scan, Chase, Attack, BackToPost, Flee, Patrol };
    
    // public containter for holding current Ai state
    public AIState currentState;

    // float fro tracking time from last state change
    public float lastStateChangeTime;

    // conainer for holding what game object the Ai is after
    public GameObject target;

    // float for holding the distance the AI can hear
    public float hearingDistance;

    // float for holding the Ai's field of view
    public float fieldOfView;

    // transform for holding the AI 
    public Transform agent;

    // Start is called before the first frame update
    public override void Start()
    {
        ChangeState(currentState);

        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // making decisions
        ProcessInputs();

        base.Update();
    }

    public override void ProcessInputs()
    {

        Debug.Log("Making Decisions");

        //checking current AI stat and then engaging said state
        switch (currentState)
        {

            case AIState.Guard:

                Debug.Log("Do Guard");

                // if statments for when AI can and cant see target to switch to chase
                if (CanSee(target))
                {
                    ChangeState(AIState.Chase);
                }

                if (CanHear(target))
                {
                    ChangeState(AIState.Chase);
                }

                break;

            case AIState.Scan:

                Debug.Log("Do Scan");

                break;



            case AIState.Chase:

                Debug.Log("Do Chase");

                DoChaseState();

                // if statments for checking for when sight of player is lost to return to guard state
                if (!CanSee(target))
                {
                    ChangeState(AIState.Guard);
                }

                if (!CanHear(target))
                {
                    ChangeState(AIState.Guard);
                }

                break;


            case AIState.Attack:

                // calling function to attack player
                DoAttackState();

                break;
        }
    }

    // Defining behavior for Guard state
    protected void DoGuardState()
    {

    }

    // Defining behavior for Seek state
    protected void DoSeekState()
    {

    }

    // Defining behavior for Chase state
    protected void DoChaseState()
    {
        // Moving toward the player
        Seek(target);
    }

    // Defining behavior for Attack state
    protected void DoAttackState()
    {
        Seek(target.transform);

        Shoot();
    }

    // Moves the AI towards the target GameObject
    protected void Seek(GameObject target)
    {
        pawn.RotateTowards(target.transform.position);

        pawn.MoveForward();
    }

    // Moves the AI towards the target Transform
    protected void Seek(Transform targetTransform)
    {
        Seek(targetTransform.gameObject);
    }

    // Executes the shooting function
    protected void Shoot()
    {
        pawn.Shoot();
    }

    // changing the AI's state and updates the time of state change
    public virtual void ChangeState (AIState newState)
    {
        currentState= newState;

        lastStateChangeTime = Time.time;
    }

    // checking if the distance to the player is less than a specified value
    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // checking if the AI can hear the player
    public bool CanHear(GameObject target)
    {
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();

        // If the object has no NoiseMaker or makes no sound returns false
        if (noiseMaker == null)
        {
            return false;
        }

        if (noiseMaker.volumeDistance <= 0)
        {
            return false;
        }

        // finding the combined hearing distance and noise range
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;

        // verifing if the target is within the audible range

        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    // function for checking if the Ai can see the player
    public bool CanSee(GameObject target)
    {
        // finding the vector from the AI to the player
        Vector3 agentToTargetVector = target.transform.position - pawn.transform.position;

        // finding the angle between the AI's forward direction and the playerr
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);

        // if statment seeing if player is in field of view
        if (angleToTarget < fieldOfView)
        {

            RaycastHit hit;

            // drawing debug line for the raycast
            Debug.DrawRay(pawn.transform.position, agentToTargetVector, Color.green);

            // if statment for seeing the player is hit by the raycast
            if (Physics.Raycast(pawn.transform.position + Vector3.up/2.0f, agentToTargetVector, out hit))
            {
                if(hit.collider.gameObject == target)
                {
                    return true;
                }
                else 
                { 
                    return false; 
                }
            }
            else
            {
                return false;
            }
            
        }
        else
        {
            return false;

        }
    }
}
