using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        pause();
    }

    public void pause() {
        Time.timeScale = 0;
    }

}
