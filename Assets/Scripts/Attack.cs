using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public GameObject Mouth;

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
        //Debug.Log("by " + gameObject.name + "root: " + gameObject.transform.root.gameObject.name );
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
        /**
         *  Attaches player scripts to other and deletes this gameObject
         */
        Debug.Log("Taking over " + other.name);

        GameObject self = gameObject.transform.root.gameObject;
        other.name = self.name;
        
        Movement movementComponent = self.GetComponent<Movement>();
        Movement otherMovementComponent = other.AddComponent<Movement>();
        otherMovementComponent.speed = movementComponent.speed;

        Player otherGrowingComponent = other.AddComponent<Player>();

        Rigidbody2D objRigidBody = other.AddComponent<Rigidbody2D>();
        objRigidBody.gravityScale = 0;
 
        connectMouth(other);

        Destroy(self);
    }

    void connectMouth(GameObject obj) {
        /**
         *  Instantiates a mouth opposite the weak point to be connected to the rigidbody via a FixedJoint
         *  Assumes obj has a child part tagged WeakPoint and there is a rigidbody connected to obj
         */

        foreach(Transform childTransform in obj.transform)
        {   
            GameObject weakPoint = childTransform.gameObject;
            if(weakPoint.tag == "WeakPoint") {
                Vector3 mouthDisplacement = obj.transform.position - weakPoint.transform.position;
                //Debug.Log(obj.transform.position + " " + weakPoint.transform.position + " " + change);
                GameObject mouth = Instantiate(Mouth,
                        obj.transform.position + mouthDisplacement,
                        Quaternion.identity);
                mouth.name = "Mouth";
                mouth.transform.parent = obj.transform;
                Rigidbody2D objRigidBody = obj.GetComponent<Rigidbody2D>();
                mouth.GetComponent<FixedJoint2D>().connectedBody = objRigidBody;
                break;
            }
        }
    }
}
