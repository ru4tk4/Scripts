using UnityEngine;
using System.Collections;

public class Boxnew : MonoBehaviour {
    public Animator BoxAni;
    
    public GameObject energy;
    public GameObject energytarget;
    public int energyV;

    public int Times =1;
    float list = 0;
    bool On;


    // Use this for initialization
    void Start () {
        BoxAni = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)&& list < Times&&On==true)
        {
            BoxAni.SetBool("Open", true);
            GameObject effect = Instantiate(energy, energytarget.transform.position, energytarget.transform.rotation) as GameObject;//creating the effect
            effect.GetComponent<dielight>().energyincrease = energyV;
            list++;
        } 
    }

    void OnTriggerEnter(Collider other1)
    {
        if (other1.tag == "Player")
        {


            On = true;
           
        }

    }

    void OnTriggerExit(Collider other1)
    {
        if (other1.tag == "Player")
        {

            On = false;
           

        }

    }

}
