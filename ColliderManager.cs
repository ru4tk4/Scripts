using UnityEngine;
using System.Collections;

public class ColliderManager : MonoBehaviour {

    public Animator[] Obj_Animator;
    bool on_off = true;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnTriggerEnter(Collider obj)
    {
        if (on_off == true)
        {
            if (obj.tag == "Player")
            {
                Obj_Animator[0].SetTrigger("Enter");
                on_off = false;
            }
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (on_off == false)
        {
            if (obj.tag == "Player")
            {
                Obj_Animator[0].SetTrigger("Exit");
                on_off = true;
            }
        }
    }
}
