using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadFoodSpawner : MonoBehaviour
{
    public GameObject badFoodPrefab;
    public float spawnTime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        Debug.Log("Spawned bad food");
        GameObject a = Instantiate(badFoodPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
    }
}