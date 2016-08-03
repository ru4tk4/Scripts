using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundEffect : MonoBehaviour {

    private NewerUI NewerUI;
    public AudioSource audio;

	// Use this for initialization
	void Start ()
    {
        NewerUI = GameObject.Find("Newer_UI").GetComponent<NewerUI>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void Event()
    {
        audio.clip = NewerUI.Sound[0];
        audio.Play();
        print("play");
    }
}
