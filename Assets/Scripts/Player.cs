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

    private float prevSize;
    void Awake()
    {
        playerhealth = gameObject.GetComponent<Health>();

    }

    void Start() {
        size = gameObject.transform.localScale.x;
        prevSize = size;
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

        if (prevSize != size) {
            float sizeChange = size - prevSize;
            scale = scale + new Vector3(sizeChange, sizeChange, sizeChange) * 0.1f;
            prevSize = size;
        }
        transform.localScale = scale;
    }

    public float getPlayerHealth() {
        return playerhealth.currentHealth;
    }
}
