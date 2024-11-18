using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // var's that hold current and max HP
    public float currentHealth;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // method for taking damage that has amount and source passed in 
    public void TakeDamage(float amount, Pawn source)
    {
        
        // subtracts current HP by amount of dmg recieved
        currentHealth -= amount;
        // logs said dmg
        Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);

        // caps hp from going into unwanted values
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // if statment for killing object that is out of HP
        if(currentHealth <= 0) 
        {
            Die(source);
        }
    }

    // method for healing
    public void Heal(float amount, Pawn source)
    {
        // adds given amount to current HP
        currentHealth += amount;
        // logs the healing
        Debug.Log(source.name + " did " + amount + " healing to " + gameObject.name);

        // capping hp value again to not overheal
        currentHealth = Mathf.Clamp(currentHealth, 0 , maxHealth);
    }

    // method for destroying Objects that have run out of HP
    public void Die(Pawn source)
    {
        Destroy(gameObject);
    }

}
