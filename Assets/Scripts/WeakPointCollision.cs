using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointCollision : MonoBehaviour
{

    public int healthThreshold = 10;
    private GameObject self;
    private int selfHealth;
    private GameObject other;
	
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("weakPointCollision script start"); 
	self = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        selfHealth = self.GetComponent<Health>().health;
    }

    void OnCollisionEnter2D(Collision2D collision) {
	Debug.Log("Collided with weak point!");
	GameObject other = collision.gameObject;

	//Debug.Log("self: " + self.name + " health: " + selfHealth);
	//Debug.Log("other: " + other.name);
	if(selfHealth <= healthThreshold) {
	    takeOverBy(other);
	} else {
	    Debug.Log(self.name + " has too much health to take over!");
	}	
    }

    void takeOverBy(GameObject otherParasite) {
	Debug.Log("Take over!");
    }

}
