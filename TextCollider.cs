using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class TextCollider : EventData {

	
	public TextUIEvent TextUI;
    public Animator[] UI; 
	public bool OnOff = true;
    public int[] number; 

	float list=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	
    void Update()
    {



    }
	void OnTriggerEnter(Collider other1) {
		if (other1.tag == "Player"&&list>0)
        {

            TextUI.TextOn(number);
            UI[0].SetTrigger("Open");
			list--;
		
		} 
		
	}

	void OnTriggerExit(Collider other1) {
		if (other1.tag == "Player")
        {
            if (OnOff == true)
            {
                list++;
            }
		} 
		
	}




}