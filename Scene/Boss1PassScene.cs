using UnityEngine;
using System.Collections;

public class Boss1PassScene : MonoBehaviour {

    public GameObject NewerUI;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 0f;
        }
    }
}
