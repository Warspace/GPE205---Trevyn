using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : Controller
{

    public enum AIState { Guard, Scan, Chase, Attack, BackToPost, Flee, Patrol };

    public AIState currentState;

    public float lastStateChangeTime;

    public GameObject target;

    public float hearingDistance;

    // Start is called before the first frame update
    public override void Start()
    {
        currentState = AIState.Chase;

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
        switch (currentState)
        {
            case AIState.Guard:

                Debug.Log("Do Guard");

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

                DoSeekState();

                if (!CanHear(target))
                {
                    ChangeState(AIState.Guard);
                }

                break;

            case AIState.Attack:

                DoAttackState();

                break;
        }
    }

    protected void DoGuardState()
    {

    }

    protected void DoSeekState()
    {

    }
    protected void DoAttackState()
    {
        Seek(target.transform);

        Shoot();
    }

    protected void Seek(GameObject target)
    {
        pawn.RotateTowards(target.transform.position);

        pawn.MoveForward();
    }

    protected void Seek(Transform targetTransform)
    {
        Seek(targetTransform.gameObject);
    }

    protected void Shoot()
    {
        pawn.Shoot();
    }

    public virtual void ChangeState (AIState newState)
    {
        currentState= newState;

        lastStateChangeTime = Time.time;
    }

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

    public bool CanHear(GameObject target)
    {
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();

        if (noiseMaker == null)
        {
            return false;
        }

        if (noiseMaker.volumeDistance <= 0)
        {
            return false;
        }

        float totalDistance = noiseMaker.volumeDistance + hearingDistance;

        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
