using UnityEngine;
using System.Collections;

public class DoorKey : MonoBehaviour {

   
    public int Key=1;
    public GameObject[] Obj;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other1)
    {
        if (other1.tag == "Player" )
        {
            Key = 0;
            foreach (GameObject A in Obj)
            {
                Destroy(A);
            }
            Destroy(gameObject);
        }

    }

}
