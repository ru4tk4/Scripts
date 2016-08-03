using UnityEngine;
using System.Collections;

public class lookatobj : MonoBehaviour {
    public Transform g;
   
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
       
        transform.LookAt(g.position);

    }
}
