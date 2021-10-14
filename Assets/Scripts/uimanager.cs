using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausegame : MonoBehaviour
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
}
