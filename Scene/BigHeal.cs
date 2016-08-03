using UnityEngine;
using System.Collections;

public class BigHeal : MonoBehaviour
{

    bool into = false; //判斷主角是否進入collider

    public GameObject Player;
    public GameObject HealEffect; //治療特效
    public GameObject CamView; //攝影機定點位置
    public GameObject HandLook; //主角手對準位置
    public GameObject StandHere; //主角站位置
    public GameObject MainCamera;
    public GameObject ZoomUI; //UI判定區域

    public float AddEnergy; //獲取能量值

    public Camera PlayerCamera;

    public float num = 0; //計算秒數
    bool count = false; //啟動計算用bool

    public Animator PressUI; //PressUI
    public Animator Albert; //主角動畫

	void Update ()
    {
        if (Input.GetButtonDown("Enter") && into == true)
        {
            PlayerCamera.GetComponent<Camerainto>().enabled = true;
            GetComponent<Animator>().SetTrigger("open");
            Albert.SetTrigger("Heal");

            PlayerCamera.GetComponent<Camerainto>().here = CamView;

            Player.transform.position = StandHere.transform.position;
            Player.transform.LookAt(HandLook.transform.position);

            Player.GetComponent<Player>().energy += AddEnergy;
            GameObject heal = Instantiate(HealEffect, Player.transform.position, Player.transform.rotation) as GameObject;

            Player.GetComponent<PlayerMove>().enabled = false;
            Player.GetComponent<GunFire>().enabled = false;
            Player.GetComponent<Input_Handler>().enabled = false;
            ZoomUI.GetComponent<HealUI>().Icon.SetActive(false);

            Destroy(ZoomUI);

            Destroy(GetComponent<BoxCollider>());
            MouseRotation.camoff = false;
            into = false;
            count = true;
        }

        if (count == true)
        {
            num += 1 * Time.deltaTime;
        }

        if (num >= 5f)
        {
            Break();
        }

        if (num >= 6f)
        {
            //count = false;
            PlayerCamera.GetComponent<Camerainto>().enabled = false;
            Destroy(this);
            count = false;
        }

	}

    void Break()
    {
        Player.GetComponent<PlayerMove>().enabled = true;
        Player.GetComponent<GunFire>().enabled = true;
        Player.GetComponent<Input_Handler>().enabled = true;

        PlayerCamera.GetComponent<Camerainto>().here = MainCamera;

        PressUI.SetTrigger("off");

        MouseRotation.camoff = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PressUI.SetTrigger("press");
            into = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PressUI.SetTrigger("off");
            PlayerCamera.GetComponent<Camerainto>().enabled = false;
            into = false;
        }
    }

}
