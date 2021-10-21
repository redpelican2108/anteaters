using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	private GameObject self;

	// Start is called before the first frame update
	void Start()
	{
		self = gameObject;
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log("Collision detected!");
		GameObject collisionPart = collision.gameObject;
		GameObject collisionRoot = collisionPart.transform.root.gameObject;
		Parasite parasiteScript = collisionRoot.GetComponent<Parasite>();

		if (collisionPart.tag == "WeakPoint" && collisionRoot.tag == "Enemy") {
			int otherHealth = parasiteScript.health;
			int takeOverThreshold = parasiteScript.takeOverThreshold;
			if(otherHealth <= takeOverThreshold) {
				takeOver(collisionRoot);
			} else {
				Debug.Log(collisionRoot.name + " has too much health to take over!");
			}
		}
	}

	void takeOver(GameObject other) {
		Debug.Log("Taking over " + other.name);
		Movement movementComponent = GetComponent<Movement>();
		Movement otherMovementComponent = other.AddComponent<Movement>();
		otherMovementComponent.speed = movementComponent.speed;

		Attack otherAttackComponent = other.AddComponent<Attack>();

		Rigidbody2D otherRigidBody = other.AddComponent<Rigidbody2D>();
		otherRigidBody.gravityScale = 0;

		Destroy(self);
	}
}
