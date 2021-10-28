using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public float sizeChange;
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

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision detected!");
        GameObject collisionPart = collision.gameObject;
        GameObject collisionRoot = collisionPart.transform.root.gameObject;
        
        if (collisionPart.CompareTag("Food")) {
            Player.scale = Player.scale * sizeChange;
        }
    }
}
