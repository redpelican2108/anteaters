using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
	
    [HideInInspector] public float currentHealth = 100;

    public float maxHealth = 100f;
    private float currentDamageTaken;
    private float damageDuration;
    private float timer = 0;
    private bool takingDamage;
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
        if(takingDamage)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            } else
            {
                takeDamage(currentDamageTaken);
                timer += damageDuration;
            }
        }
    }

    public void takeDamage(float damageAmount) {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) {
            currentHealth = 0;
            if (OnDeath != null) {
                OnDeath();
                if(gameObject.tag == ("Enemy"))
                {
                    gameObject.GetComponent<Parasite>().EnemyDeath();
                }
                Destroy(gameObject);
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Mouth")
        {
            takingDamage = true;
            currentDamageTaken = collision.GetComponent<Mouth>().damage;
            damageDuration = collision.GetComponent<Mouth>().damageDuration;
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Mouth")
        {
            takingDamage = false;
            timer = 0;
        }
    }


}
