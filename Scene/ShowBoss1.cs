using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowBoss1 : MonoBehaviour {

    public GameObject PlayerCamera;
    public GameObject Camera;
    public GameObject AniObj;
    public GameObject NewerUI;
    public GameObject Black;
    public GameObject Player;
    public GameObject[] Monster;

    bool on_off = false;
    bool fade = false;
    float darkness = 0f;
    float count = 0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (on_off == true) {
            Player.GetComponent<PlayerMove>().enabled = false;
            Player.GetComponent<Input_Handler>().enabled = false;
            NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 0f;
            count += 1f * Time.deltaTime;
            darkness += 10f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
            NewerUI.SetActive(false);
            AniObj.SetActive(true);
            AniObj.GetComponent<Animator>().SetTrigger("Open");
        }

        if (count >= 0.8f) {
            PlayerCamera.GetComponent<Camera>().enabled = false;
            darkness -= 8f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
            Camera.SetActive(true);
            gameObject.GetComponent<Animator>().SetTrigger("Open");
            on_off = false;
        }

        if (fade == true)
        {
            darkness += 1f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            on_off = true;
        }
    }


    public void Out()
    {
        fade = false;
        darkness = 0;
        Black.SetActive(false);
        NewerUI.SetActive(true);
        NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 1f;
        Player.GetComponent<PlayerMove>().enabled = true;
        Player.GetComponent<Input_Handler>().enabled = true;
        PlayerCamera.GetComponent<Camera>().enabled = true;
        foreach (GameObject A in Monster) {
            A.SetActive(true);
        }
        Destroy(Camera);
        Destroy(AniObj);
        Destroy(gameObject);
    }

    public void FadeOut() {
        darkness = 0;
        fade = true;
        count = 0;
    }
}
