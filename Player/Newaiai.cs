using UnityEngine;
using System.Collections;

public class Newaiai : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    RaycastHit hit;

    void Ray()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.forward, out hit, 5000f, 1023))
        {
          
        }
    }

}
