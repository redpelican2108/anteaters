using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
	
    [HideInInspector] public int currentHealth = 100;

    public int maxHealth = 100;
    public event Action OnHealthChange;
    public event Action OnDeath;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damageAmount) {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) {
            currentHealth = 0;
            if (OnDeath != null) {
                OnDeath();
            }
        }
        if (OnHealthChange != null) {
            OnHealthChange();
        }
    }

    public void heal(int healAmount) {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        if (OnHealthChange != null) {
            OnHealthChange();
        }
    }

    public float getHealthPercent() {
        return (float) currentHealth / maxHealth;
    }
}
