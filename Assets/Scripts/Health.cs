using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
	
    //[HideInInspector] public float currentHealth = 100;

    public float currentHealth = 100;
    
    public float maxHealth = 100f;
    public float takeOverThreshold = 30f;
    public event Action OnHealthChange;
    public event Action OnDeath;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damageAmount) {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) {
            if (OnDeath != null) {
                OnDeath();
                if(gameObject.tag == ("Enemy"))
                {
                    gameObject.GetComponent<Parasite>().EnemyDeath();
                    Destroy(gameObject);
                }
                
            }
        }
        if (OnHealthChange != null) {
            OnHealthChange();
        }
    }

    public void heal(float healAmount) {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        if (OnHealthChange != null) {
            OnHealthChange();
        }
    }

    public void setHealth(float hp) {
        if (hp >= 0 && hp < maxHealth) {
            currentHealth = hp;
        } else {
            Debug.Log("Error, setting health to invalid value");
        }

        if (OnHealthChange != null) {
            OnHealthChange();
        }
    }

    public float getHealthPercent() {
        return (float) currentHealth / maxHealth;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Mouth")
        {
            collision.GetComponent<Mouth>().DealDamage(this);
        }
    }
}
