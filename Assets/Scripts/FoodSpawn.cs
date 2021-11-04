using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject food;
    public float rate;
    public float spawnXRange;
    public float spawnYRange;
    public int foodLimit;
    void Start() 
    {
        InvokeRepeating("Generate", 0, rate);
    }
    void Update()
    {

    }
    void Generate()
    {
        float x = Random.Range(-spawnXRange, spawnXRange);
        float y = Random.Range(-spawnYRange, spawnYRange);

        Vector3 target = new Vector3(x, y, 0);
    
        int count = GameObject.FindGameObjectsWithTag("Food").Length;
        if (count < foodLimit) 
        {
            Instantiate(food, target, Quaternion.identity);
        }
        
    }
    
}
