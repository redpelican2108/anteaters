using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uimanager : MonoBehaviour
{
    public GameObject PauseScreen;
    
    public void pause() {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
    }

    public void resume() {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }

    }
}
