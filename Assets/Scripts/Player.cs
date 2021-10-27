using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int size = 1;
    public int goal = 25;
    public int damage = 1;
    static public Vector3 scale;

    public event Action OnPlayerDeath;
    public event Action OnPlayerWin;

    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
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

        transform.localScale = scale;

    }
}
