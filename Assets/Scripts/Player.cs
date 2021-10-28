using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    Health playerhealth;
    public float size = 1;
    public int goal = 25;
    static public Vector3 scale;
    public event Action OnPlayerDeath;
    public event Action OnPlayerWin;

    void Awake()
    {
        playerhealth = gameObject.GetComponent<Health>();
        scale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerhealth.currentHealth <= 0) {
            if(OnPlayerDeath != null) {
                OnPlayerDeath();
            }
        }

        if (size >= goal) {
            if(OnPlayerWin != null) {
                OnPlayerWin();
            }
        }

        transform.localScale = scale;

    }

    public float getPlayerHealth() {
        return playerhealth.currentHealth;
    }
}
