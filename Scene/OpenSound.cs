using UnityEngine;
using System.Collections;

public class OpenSound : MonoBehaviour
{
    public GameObject[] Sounds;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject S in Sounds)
            {
                S.SetActive(true);
            }
        }
    }
}
