using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowardlyAiController : AiController
{
    public enum CowardlyAIState { Cower, Cry };

    public CowardlyAIState currentAIControllerState;
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void ProcessInputs()
    {
        switch(currentAIControllerState)
        {

            case CowardlyAIState.Cower:
                break;
        }
        base.ProcessInputs();
    }
}
