using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource bgm;
    private static AudioManager instance = null;
    float vol;
    void Awake() {
        if (instance != null && instance != this) {
             Destroy(this.gameObject);
             return;
        } else {
             instance = this;
         }

        DontDestroyOnLoad(this.gameObject);
        vol = PlayerPrefs.GetFloat("bgm vol");
        bgm.volume = vol;
    }
}
