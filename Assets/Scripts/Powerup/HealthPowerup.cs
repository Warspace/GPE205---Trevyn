using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class HealthPowerup : Powerup
{
    public float healthToAdd;

    // Start is called before the first frame update
    public override void Apply(PowerupManager target)
    {
        // getting the health component
        Health targetHealth = target.gameObject.GetComponent<Health>();

        // if fucntion to apply healing to target if called on 
        if (targetHealth != null)
        {

            targetHealth.Heal(healthToAdd, target.gameObject.GetComponent<Pawn>());
        }
        
    }

    // function for removing hp from the target
    public override void Remove(PowerupManager target)
    {
        // calling health component of target
        Health targetHealth = target.gameObject.GetComponent<Health>();

        // if function to apply damage to object if called on
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(healthToAdd, target.gameObject.GetComponent<Pawn>());
        }
    }

}
