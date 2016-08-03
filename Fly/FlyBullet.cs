using UnityEngine;
using System.Collections;

public class FlyBullet : MonoBehaviour {
    public int DEL=10;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player"| other.tag == "Moster")
        {
            other.transform.GetComponent<FlyHP>().HP -= DEL;
            Destroy(this);
        }
        
    }

}
