using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD;

public class muuuuuuuu : MonoBehaviour {
    public float kkkkk;
    [FMODUnity.EventRef]
    public string inputSound = "";
    FMOD.Studio.EventInstance backgroundMusic;
    FMOD.Studio.ParameterInstance currentHealth;
    // Use this for initialization
    void Start () {
        backgroundMusic = FMODUnity.RuntimeManager.CreateInstance(inputSound);
        backgroundMusic.getParameter("enemy", out currentHealth);
        backgroundMusic.start();
        currentHealth.setValue(2f);
    }
	
	// Update is called once per frame
	void Update () {
        //  FMODUnity.RuntimeManager.PlayOneShot(inputSound);
       

        //backgroundMusic.setParameterValue("die", 1);
    }
}
