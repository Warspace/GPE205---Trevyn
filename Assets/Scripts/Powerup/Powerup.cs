using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup
{
    public float duration;
    public bool isPermanent;
    // Start is called before the first frame update
    public abstract void Apply(PowerupManager target);

    // Update is called once per frame
    public abstract void Remove(PowerupManager target);

}
