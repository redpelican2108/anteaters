using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Transform player;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg;
        if(angle > 0 && player.position.y < transform.position.y)
        {
            angle += 180;
        } else if(angle < 0 && player.position.x < transform.position.x)
        {
            angle += 180;
        }

        
        Quaternion rotation = Quaternion.Euler(new Vector3(0,0,angle));

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        
        if((transform.position - player.position).magnitude > 0.5f)
        {
            transform.Translate((player.position - transform.position).normalized * speed * Time.deltaTime);
        }
    }
}
