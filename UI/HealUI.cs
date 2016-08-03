using UnityEngine;
using System.Collections;

public class HealUI : MonoBehaviour
{
    public GameObject Icon;
    public GameObject Target;
    public Camera PlayerCamera;

    void OnTriggerEnter(Collider other1)
    {
        if (other1.tag == "Player")
        {
            Icon.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other1)
    {
        if (other1.tag == "Player")
        {
            Icon.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other1)
    {
        if (other1.tag == "Player")
        {
            Icon.transform.position = PlayerCamera.WorldToScreenPoint(Target.transform.position);
        }
    }
}
