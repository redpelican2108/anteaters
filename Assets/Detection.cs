using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public MonoBehaviour script;
    // Start is called before the first frame update
    public void Toggle()
    {
        script.enabled = !script.isActiveAndEnabled;
    }

    // Update is called once per frame
  
}
