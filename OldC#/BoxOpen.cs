using UnityEngine;
using System.Collections;

public class BoxOpen : MonoBehaviour
{
    bool On;
    public GameObject energy;
    public GameObject target;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Look")&&On==true)
        {

        }
    }

    void OnTriggerEnter(Collider other1)
    { 
        if (other1.tag == "Player")
        {
            On = true;

        }               
    }
}
