using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColliderEvent : MonoBehaviour{
	public GameObject StartEvent ;
	public GameObject StartPosition;
    public float Times;
    float list=0;
    
 
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }



  void OnTriggerEnter(Collider other1) {
		if (other1.tag == "Player"&& list < Times) {
           
                print("1");
                GameObject effect = Instantiate(StartEvent, StartPosition.transform.position, StartPosition.transform.rotation) as GameObject; //creating the effect
                list++;
                //effect.transform.parent = StartPosition.transform;
  
        } 

	}
}

