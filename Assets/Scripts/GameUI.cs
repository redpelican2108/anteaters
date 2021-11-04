using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject GameOverScreen;

    public Text goalvalue;
    public Text sizevalue;
    public Text hpvalue;
    public string NextLevel; 
    
    Player player;
    bool gameover = false;

    void Start() {
        player = FindObjectOfType<Player>();
    
        player.OnPlayerDeath += gameOver;
        player.OnPlayerWin += gameWon;

        if (goalvalue != null && sizevalue != null && hpvalue != null) {
            goalvalue.text = player.goal.ToString();
            sizevalue.text = player.size.ToString();
            hpvalue.text = "100";
            player.getPlayerHealth().ToString();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameover)
        {
            pause();
        }

        if (goalvalue != null && sizevalue != null && hpvalue != null) {
            goalvalue.text = player.goal.ToString();
            sizevalue.text = player.size.ToString();
            hpvalue.text = player.getPlayerHealth().ToString();
        }
    }

     public void pause() {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
    }

    public void resume() {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void gameOver() {
        gameover = true;
        GameOverScreen.SetActive(true);
    }

    public void gameWon() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
