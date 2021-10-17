using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour
{
    static public Vector3 size;
    
    // Start is called before the first frame update
    void Start()
    {
        size = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = size;
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    

}  
