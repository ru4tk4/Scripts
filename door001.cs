using UnityEngine;
using System.Collections;

public class door001 : MonoBehaviour {

    public Animator Ani01;
    public Animator Ani02;
    public Animator Ani03;
    //public Animator door2;
    public bool on_off = true;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        

    }



    void OnTriggerEnter(Collider gameObject) {

        if (on_off == true)
        {

            if (gameObject.tag == "Player")
            {
                Ani01.SetBool("Event", true);
                Ani02.SetBool("Event", true);
                Ani03.SetBool("Event", true);  
                //door2.SetBool("door002", true);
            }

        }


    }
        void OnTriggerExit(Collider gameObject) {

        if (on_off == true)
        {
            if (gameObject.tag == "Player")
            {
                Ani01.SetBool("Event", false);
                Ani02.SetBool("Event", false);
                Ani03.SetBool("Event", false);
                //door2.SetBool("door002", false);
            }
        }


        }


    }


