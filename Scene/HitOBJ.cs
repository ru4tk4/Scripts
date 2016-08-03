using UnityEngine;
using System.Collections;

public class HitOBJ : MonoBehaviour {
    Rigidbody rb;
    public Rigidbody[] rbs;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision)
    {

       // if (collision.gameObject.tag == "player"|| collision.gameObject.tag == "Boss")
        //{
            rb.isKinematic = false;
            foreach(Rigidbody r in rbs)
            {
                r.isKinematic = false;
                r.gameObject.GetComponent<HitOBJ>().rr();
            }
        //}
        Destroy(this);
    }
    public void rr()
    {
        foreach (Rigidbody r in rbs)
        {
            r.isKinematic = false;
        }
        Destroy(this);
    }

}
