using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint: MonoBehaviour
{
    /*
     * To use, attach a gameObject to a parasite as the weak point
     * attach this script to weakpoint
     * attach a circlecollider2d to weak point
     * attach a rigidbody2d to weak point, and set gravity to 0 and body type to kinematic
     *
     *
     */
    public int healthThreshold = 10;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
   
}
