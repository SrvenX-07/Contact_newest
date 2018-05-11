using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicEdisonSettings : MonoBehaviour
{
    public GameObject bg;
    AudioSource audio;
    public Slider slider;
    // Use this for initialization
    void Start ()
    {
        audio = bg.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    audio.volume = slider.value;
	}
}
