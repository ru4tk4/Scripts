using UnityEngine;
using System.Collections;

public class BakeTwo : MonoBehaviour {
    public float Ds = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Boss")
        {
            other.gameObject.transform.LookAt(GameObject.Find("Albert2").transform);
            other.gameObject.AddComponent<Bake>();
            other.gameObject.GetComponent<Bake>().speed = Ds;
            Destroy(this);
            Destroy(gameObject,3);
        }
    }
}
