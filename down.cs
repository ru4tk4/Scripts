using UnityEngine;
using System.Collections;

public class down : MonoBehaviour
{

    public Animator Ani;
    public Animator Ani0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter(Collider gameObject)
    {

        if (gameObject.tag == "Player")
        {

            Ani.SetBool("Event", true);


        }
    }


    void OnTriggerExit(Collider gameObject)
    {

        if (gameObject.tag == "Player")
        {

            Ani.SetBool("Event", false);



        }

    }
}
