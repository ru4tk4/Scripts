using UnityEngine;
using System.Collections;

public class NormalDoor : MonoBehaviour {

    public Animator Door;
    public Animator UI;

    void Start()
    { }

    void Update()
    { }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Door.SetBool("Open", true);
        }        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Door.SetBool("Open", false);
        }
    }

    public void UIAni()
    {
        UI.SetTrigger("Open");
    }
}
