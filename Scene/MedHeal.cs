using UnityEngine;
using System.Collections;

public class MedHeal : MonoBehaviour
{
    bool into = false; //判斷主角進入collider
    int PressE = 0; //判斷E按第幾下;

    public GameObject[] EnergyBall; //裡面能量球
    public GameObject Player; //玩家
    public GameObject HealEffect; //補血特效
    public GameObject ZoomUI;

    public float AddEnergy; //外部調整能量值 

    float time;
    bool flyto = false;

    void Update()
    {
        if (Input.GetButtonDown("Enter") && into == true)
        {
            GetComponent<Animator>().SetTrigger("Open");
            flyto = true;
            PressE += 1;           
        }

        if (PressE >= 2 && flyto == true)
        {
            FlyToPlayer();
        }

        if (time >= 0.5f)
        {
            foreach (GameObject get in EnergyBall)
            {
                GameObject heal = Instantiate(HealEffect, Player.transform.position, Player.transform.rotation) as GameObject;

                heal.transform.parent = Player.transform;

                Player.GetComponent<Player>().energy += AddEnergy;
                ZoomUI.GetComponent<HealUI>().Icon.SetActive(false);

                Destroy(ZoomUI);
                Destroy(get);
                Destroy(GetComponent<BoxCollider>());

                into = false;
                Destroy(this);
            }
        }
          
    }

    void FlyToPlayer()
    {
        foreach (GameObject fly in EnergyBall)
        {
            Vector3 local = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.5f, Player.transform.position.z);
            fly.transform.LookAt(local);
            fly.transform.position = Vector3.Lerp(fly.transform.position, local, 10f * Time.deltaTime);

            time += 0.5f * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other2)
    {
        if (other2.tag == "Player")
        {
            into = true;
        }
    }

    void OnTriggerExit(Collider other2)
    {
        if (other2.tag == "Player")
        {
            into = false;
        }
    }
}
