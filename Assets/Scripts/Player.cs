using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public int size = 10;
    public int goal = 25;
    Health playerhealth;

    public event Action OnPlayerDeath;
    public event Action OnPlayerWin;

    void Awake()
    {
        playerhealth = gameObject.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerhealth.currentHealth <= 0) {
            if(OnPlayerDeath != null) {
                OnPlayerDeath();
            }
            Destroy (gameObject);
        }

        if (size >= goal) {
            if(OnPlayerWin != null) {
                OnPlayerWin();
            }
        }
    }

    public int getPlayerHealth() {
        return playerhealth.currentHealth;
    }
}
