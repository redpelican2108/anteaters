using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parasite : MonoBehaviour
{
    public float size = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(size,size,size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDeath()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().size += size;
    }
}
