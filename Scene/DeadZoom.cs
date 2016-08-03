using UnityEngine;
using System.Collections;

public class DeadZoom : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Albert2").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            player.energy = 0;
            player.hp -= 100;
        }
    }
}
