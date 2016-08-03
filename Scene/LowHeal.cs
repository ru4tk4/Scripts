using UnityEngine;
using System.Collections;

public class LowHeal : MonoBehaviour
{

    bool into = false; //判斷主角是否進入collider

    public GameObject Player;
    public GameObject HealEffect; //補血特效
    public GameObject Ball;
    public GameObject ZoomUI;

    public float AddEnergy;

	void Update ()
    {
        if (Input.GetButtonDown("Enter") && into == true)
        {
            GameObject heal = Instantiate(HealEffect, Player.transform.position, Player.transform.rotation) as GameObject;
            heal.transform.parent = Player.transform;

            ZoomUI.GetComponent<HealUI>().Icon.SetActive(false);
            Player.GetComponent<Player>().energy += AddEnergy;

            into = false;

            Destroy(ZoomUI);
            Destroy(Ball);
            Destroy(GetComponent<BoxCollider>());
            Destroy(this);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            into = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            into = false;
        }
    }
}
