using UnityEngine;
using System.Collections;

public class Into : MonoBehaviour {

	public GameObject att;
	public GameObject btt;
	public GameObject ctt;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		att.transform.position = btt.transform.position;
		att.transform.rotation = Quaternion.Euler(att.transform.rotation.x, Camera.main.transform.eulerAngles.y, att.transform.rotation.z);
		//att.transform.rotation = ctt.transform.rotation;
	}
}
