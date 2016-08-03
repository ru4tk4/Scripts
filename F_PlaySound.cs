using UnityEngine;
using System.Collections;

public class F_PlaySound : MonoBehaviour {

    [FMODUnity.EventRef]
    public string inputSound = "";

   
    void Start () {
        FMODUnity.RuntimeManager.PlayOneShot(inputSound,transform.position);
    }
	
	
}
