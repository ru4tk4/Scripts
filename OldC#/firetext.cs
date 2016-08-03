using UnityEngine;
using System.Collections;

public class firetext : MonoBehaviour {
	public GameObject bulles;
	public GameObject firehere;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			GameObject bulle = Instantiate(bulles, firehere.transform.position, firehere.transform.rotation) as GameObject;
			
			bulle.GetComponent<Rigidbody>().AddForce((transform.forward + new Vector3(0, 0f,0)) * 1000);
		}
		
	}

}
