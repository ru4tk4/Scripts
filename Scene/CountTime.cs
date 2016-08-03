using UnityEngine;
using System.Collections;

public class CountTime : MonoBehaviour {

    public GameObject LockUI;
    public GameObject time;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (time.GetComponent<time>().timer <=0)
        {
            Destroy(LockUI);
            GetComponent<Animator>().SetBool("Open", true);
        }
	}
}
