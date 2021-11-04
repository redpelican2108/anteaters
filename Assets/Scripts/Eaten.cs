using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eaten : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time < 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Mouth")
        {
            collision.GetComponentInParent<Player>().size += 0.1f;
            collision.GetComponentInParent<Health>().heal(hp);
            Destroy(gameObject);
        }
    }
}
