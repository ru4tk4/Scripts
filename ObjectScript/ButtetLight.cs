using UnityEngine;
using System.Collections;


public class ButtetLight : MonoBehaviour {

	public Light nuttetlight;
	public float listtime = 0.01f;
	bool ontrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ontrigger == true) {
			if(nuttetlight.intensity > 0){
			nuttetlight.intensity -= listtime;
			
			}
		}

	}


	void OnTriggerEnter(Collider other){
		ontrigger = true;

	}
}
