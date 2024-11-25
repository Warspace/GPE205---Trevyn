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
        
        Health targetHealth = target.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.Heal(healthToAdd, target.gameObject.GetComponent<Pawn>());
        }
        
    }

    // Update is called once per frame
    public override void Remove(PowerupManager target)
    {
        Health targetHealth = target.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(healthToAdd, target.gameObject.GetComponent<Pawn>());
        }
    }

}
