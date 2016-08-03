using UnityEngine;
using System.Collections;

public class HitOBJ1 : MonoBehaviour {
    Rigidbody rb;
    public Rigidbody[] rbs;
    public GameObject Effect;
    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rbs = GetComponentsInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public void rrr()
    {
        foreach (Rigidbody r in rbs)
        {
            r.isKinematic = false;
            r.gameObject.GetComponent<HitOBJ>().rr();
        }
    }



    void OnTriggerEnter(Collider other)

    {


        if (other.tag == "Boss")

        {
           
            foreach(Rigidbody r in rbs)
            {
                r.isKinematic = false;
                
                // r.gameObject.GetComponent<HitOBJ>().rr();
            }
            GameObject bulle1141 = Instantiate(Effect, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            rb.isKinematic = true;
            Destroy(this);
        }
      
    }
    

}
