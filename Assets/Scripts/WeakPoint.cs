using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    GameObject selfWeakPoint;
    GameObject selfRoot;
    // Start is called before the first frame update
    void Start()
    {
        selfWeakPoint = gameObject;
        selfRoot = gameObject.transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger detected");
        GameObject collisionPart = collision.gameObject;
        GameObject collisionRoot = collisionPart.transform.root.gameObject;
        if (collisionPart.tag == "Mouth" && collisionRoot.tag == "Player") {
            Health selfHealthScript = selfRoot.GetComponent<Health>();
            float selfHealth = selfHealthScript.currentHealth;
            if (selfHealth <= selfHealthScript.takeOverThreshold) {
                takeOverBy(collisionRoot);
            } else {
                Debug.Log("Enemy's health " + selfHealth + " is higher than take over threshold " + selfHealthScript.takeOverThreshold);
            }
        } else {
            Debug.Log("Collided with " + collisionPart.name + " of " + collisionRoot.name);
        }
    }

    public void takeOverBy(GameObject player) {
        Debug.Log("Take over by " + player.name);
        player.transform.position = selfRoot.transform.position;
        player.transform.rotation = selfRoot.transform.rotation; 
        player.GetComponent<Player>().size = selfRoot.transform.localScale.x;
        
        player.GetComponent<Health>().currentHealth = selfRoot.GetComponent<Health>().currentHealth;

        Debug.Log("player health change to " + selfRoot.GetComponent<Health>().currentHealth);
        Destroy(selfRoot);
    }

}
