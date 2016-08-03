using UnityEngine;
using System.Collections;

public class Bake : MonoBehaviour {
	CharacterController hero;  
	public Vector3 pos =  new Vector3(-8,0,0);

	public float speed = 20;
	public float speed1 = 0.6f;


	// Use this for initialization
	void Start () {
		hero = GetComponent<CharacterController>(); 
	}
	
	// Update is called once per frame
	void Update () {

		GOGO ();

	}
	
	void GOGO(){


		if (speed > 0) {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            hero.SimpleMove (forward * -speed);
			speed -= speed1;
		} else {
			Destroy(this);
		}



	}





}
