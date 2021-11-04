using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public Vector3 sizeChange;
    public int damage;
    public float damageDuration;
    public GameObject MouthObject;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void DealDamage(Health health)
    {
        if(timer <= 0)
        {
            health.takeDamage(damage);
            timer += damageDuration;
        }
            
        
    }

}
