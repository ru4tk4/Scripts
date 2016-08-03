using UnityEngine;
using System.Collections;

public class FireCollider : MonoBehaviour {
    public bool keep;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {

       if(other.tag == "Player")
        {
            if (other.gameObject.GetComponent<FireDE>())
            {
                other.gameObject.GetComponent<FireDE>().De();
                if (keep == false)
                {
                    Destroy(this);
                }
            }
           
        }

    }

    
}
