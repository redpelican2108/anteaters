using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public Vector3 sizeChange;
    public int damage;
    public float damageDuration;
    public GameObject MouthObject;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            Debug.Log("Collision detected!");
            if (collision.gameObject.CompareTag("Food")) {
                Player.scale += sizeChange;
                Destroy(collision.gameObject);
            }
        }
            
        
    }
}
