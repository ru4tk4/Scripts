using UnityEngine;
using System.Collections;

public class SoundEvent : MonoBehaviour {

    public AudioSource SelfAudioSource;
    public AudioClip[] SFX;

    void Start() {
        SelfAudioSource = gameObject.GetComponent<AudioSource>();
    }

    void EventOpen() {
        AudioSource Sound = SelfAudioSource.GetComponent<AudioSource>();
        Sound.PlayOneShot(SFX[0], 1);
    }
}
