using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

    public Animator doorain;
    public DoorKey[] DoorKeys;
    public bool door_on = false; //判斷是否有沒有鑰匙
    //public Animator point;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.E) && door_on == true)
        {
            doorain.SetBool("Open", true);
            door_on = false;
        }
	}

    void OnTriggerEnter(Collider other1)
    {
        if (other1.tag == "Player" )
        {
            int KeyNumber = 0;
            foreach (DoorKey DoorKey in DoorKeys)
            {
                KeyNumber += DoorKey.Key;
            }

            if (KeyNumber == 0)
            {
                door_on = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            door_on = false;
        }
    }

}
