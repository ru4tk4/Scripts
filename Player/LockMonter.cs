﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class LockMonter : MonoBehaviour {
    public GameObject[] monters;
   
    public ArrayList mm = new ArrayList();
    // Use this for initialization

   

    void Start () {
        
       // mm.Add(gameObject);
        // monters = mm.ToArray()as GameObject[];
        
	}
	
	// Update is called once per frame
	void Update () {

        monters = new GameObject[mm.Count];
        mm.CopyTo(monters);
    }

    void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Boss")
        {
            mm.Add(other.gameObject);
        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Boss")
        {
            foreach (GameObject g in monters)
            {
                if (g == other.gameObject)
                {
                    mm.Remove(g);
                }


            }
        }
        

    }

}
