using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject Food;
    public float Rate;
    void Start() 
    {
        InvokeRepeating("Generate", 0, Rate);
    }
    void Update()
    {

    }
    void Generate()
    {
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;

        Instantiate(Food, Target, Quaternion.identity);
    }
    
}