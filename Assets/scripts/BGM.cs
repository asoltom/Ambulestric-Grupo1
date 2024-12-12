using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    public Slider slider;
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setAudio()
    {
        bgm.volume = slider.value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
