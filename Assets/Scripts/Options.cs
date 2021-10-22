using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    public Slider volumeSlider;
    AudioSource bgm; 
    float vol;
    // Start is called before the first frame update
    void Start()
    {
        bgm = FindObjectOfType<AudioSource>();
        vol = PlayerPrefs.GetFloat("bgm vol");
        volumeSlider.value = vol;
        bgm.volume = vol;
    }

    // Update is called once per frame
    void Update()
    {
        volumeSlider.onValueChanged.AddListener(setVolume);
    }

    public void setVolume(float value) {
        bgm.volume = value;
        PlayerPrefs.SetFloat("bgm vol", value);
    }
}
