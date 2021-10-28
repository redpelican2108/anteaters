using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Health myHealth;
    Quaternion rotation;
    Vector3 offset;

    
    // Start is called before the first frame update
    void Start()
    {
        myHealth = this.gameObject.GetComponentInParent<Health>();
        offset = this.gameObject.transform.localPosition;

        myHealth.OnHealthChange += displayChangedHealth;
        myHealth.OnDeath += destroyHealthBarOnDeath;
    }

    void Awake() {
        rotation = transform.rotation;
    }

    void LateUpdate() {
        transform.rotation = rotation;
        this.gameObject.transform.position = this.gameObject.transform.parent.localPosition + offset;
        // this.gameObject.transform.parent.transform.position +
    }

    // Update is called once per frame
    void Update()
    {
    }

    void displayChangedHealth() {
        transform.Find("Bar").localScale = new Vector3(myHealth.getHealthPercent(), 1);
    }

    void destroyHealthBarOnDeath() {
        Destroy (gameObject);
        Debug.Log("Healthbar destroyed");
    }
}
