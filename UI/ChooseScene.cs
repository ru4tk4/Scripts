using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseScene : MonoBehaviour
{
    public GameObject MainObj;
    public GameObject Black;
    public GameObject Player;
    public GameObject MainCamera;
    public PlayerSave PlayerSave;
   // public AsyncOperation E;
    public string[] SceneName;

    public AudioSource SX;
    public AudioClip[] Sound;


    bool on_off = false;
    bool time = false;
    bool open = false;
    float count = 0;

    void Start()
    {
        PlayerSave = GameObject.Find("Albert2").GetComponent<PlayerSave>();
        //E.allowSceneActivation = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && on_off == false)
        {
            Player.GetComponent<Player>().enabled = false;
            Player.GetComponent<PlayerMove>().enabled = false;
            Player.GetComponent<GunFire>().enabled = false;
            Player.GetComponent<Input_Handler>().enabled = false;
            MainCamera.GetComponent<MouseRotation>().enabled = false;
            NewerUI.Gamepaused = true;
            Screen.lockCursor = false;
            MainObj.SetActive(true);
            MainObj.GetComponent<Animator>().SetTrigger("Open");
            open = true;
            on_off = true;
            time = false;
            count = 0;
        }
        if (Input.GetKey(KeyCode.V) && on_off == true)
        {
            Player.GetComponent<Player>().enabled = true;
            Player.GetComponent<PlayerMove>().enabled = true;
            Player.GetComponent<GunFire>().enabled = true;
            Player.GetComponent<Input_Handler>().enabled = true;
            MainCamera.GetComponent<MouseRotation>().enabled = true;
            NewerUI.Gamepaused = false;
            Screen.lockCursor = true;
            MainObj.GetComponent<Animator>().SetTrigger("Close");
            time = true;
            open = false;
            on_off = false;
        }

        if (time == true)
        {
            count += 1 * Time.deltaTime;
        }

        if (count >= 4)
        {
            MainObj.SetActive(false);
            time = false;
        }
    }

    public void Choose11()
    {
        Black.SetActive(true);
        NewerUI.Gamepaused = true;
        PlayerSave.SceneChange(SceneName[0]);
        Destroy(this);
    }

    public void Choose12()
    {
        Black.SetActive(true);
        NewerUI.Gamepaused = true;
        PlayerSave.SceneChange(SceneName[1]);
        Destroy(this);
    }


    public void Choose1B()
    {
        Black.SetActive(true);
        NewerUI.Gamepaused = true;
        PlayerSave.SceneChange(SceneName[2]);
        Destroy(this);
    }


    public void Choose21()
    {
        Black.SetActive(true);
        NewerUI.Gamepaused = true;
        PlayerSave.SceneChange(SceneName[3]);
        Destroy(this);
    }


    public void Choose22()
    {
        Black.SetActive(true);
        NewerUI.Gamepaused = true;
        PlayerSave.SceneChange(SceneName[4]);
        Destroy(this);
    }


    public void Choose23()
    {
        Black.SetActive(true);
        NewerUI.Gamepaused = true;
        PlayerSave.SceneChange(SceneName[5]);
        Destroy(this);
    }


    public void Choose2B()
    {
        Black.SetActive(true);
        NewerUI.Gamepaused = true;
        PlayerSave.SceneChange(SceneName[6]);
        Destroy(this);
    }

    public void Enter()
    {
        AudioSource S = SX.GetComponent<AudioSource>();
        S.PlayOneShot(Sound[0], 1);
    }

    public void Down()
    {
        AudioSource S = SX.GetComponent<AudioSource>();
        S.PlayOneShot(Sound[1], 1);
    }
}
