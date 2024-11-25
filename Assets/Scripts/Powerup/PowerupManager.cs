using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    // listing active powerups
    public List<Powerup> powerups;

    // list acting as powerup removal queue
    private List<Powerup> removedPowerupQueue;
    // Start is called before the first frame update
    void Start()
    {
        // starting the list of powerups
        powerups = new List<Powerup> ();
    }

    // Update is called once per frame
    void Update()
    {
        // decreasing time on all current powerups
        DecrementPowerupTimers();
    }

    private void LateUpdate()
    {
        // calling function to remove queued powerups
        ApplyRemovePowerupsQueue();
    }

    // Adds a new powerup to the list and applies its effects
    public void Add (Powerup powerupToAdd)
    {
        powerupToAdd.Apply(this);

        powerups.Add(powerupToAdd);
    }

    // function to add powerup to poweruptoremovequeue 
    public void Remove(Powerup powerupToRemove)
    {
        powerupToRemove.Remove(this);

        removedPowerupQueue.Add(powerupToRemove);
    }

    // fucntion for decrementing timers on powerups
    public void DecrementPowerupTimers()
    {
        foreach (Powerup powerup in powerups)
        {
            if (!powerup.isPermanent)
            {
                powerup.duration -= Time.deltaTime;

                if (powerup.duration <= 0)
                {
                    Remove(powerup);
                }
            }
        }
    }

    // fuction for deleating objects in the removepowerupqueue
    private void ApplyRemovePowerupsQueue()
    {
        foreach (Powerup powerup in removedPowerupQueue)
        {
            powerups.Remove(powerup);
        }
        removedPowerupQueue.Clear();
    }
}
