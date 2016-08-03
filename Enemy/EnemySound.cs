using UnityEngine;
using System.Collections;

public class EnemySound : MonoBehaviour {

    public AudioSource footstep;
    public AudioClip[] sound;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void SoundPlay() {
        AudioSource SX = footstep.GetComponent<AudioSource>();
        SX.PlayOneShot(sound[0], 1);
    }
}
