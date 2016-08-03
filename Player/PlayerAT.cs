using UnityEngine;
using System.Collections;

public class PlayerAT : MonoBehaviour {
    static public GameObject SightTarget;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // print(SightTarget.tag);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss") {
            
            SightTarget = other.gameObject;

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boss")
        {
           
            SightTarget = null;

        }
        SightTarget = null;
    }



    }
