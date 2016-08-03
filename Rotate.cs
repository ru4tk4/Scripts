using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float Add;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Rotate(0, Add * Time.deltaTime, 0);
    }
}
