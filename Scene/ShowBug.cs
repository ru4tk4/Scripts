using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowBug : MonoBehaviour {

    private Player Player;

    public GameObject Albert;
    public GameObject Stand;
    public GameObject LookAt;
    public GameObject NewerUI;
    public GameObject Icon;
    public GameObject IconCollider;
    public GameObject Door;
    public GameObject Black;
    public GameObject PlayerCamera;
    public GameObject Camera;
    public GameObject CameraObj;
    public GameObject[] Bug;
    public GameObject[] EndObj;

    public AudioSource SelfSource;
    public AudioClip SelfClip;

    bool on_off = false;
    bool count = false;
    bool fade = false;
    float darkness = 0f;
    float time = 0f;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Albert2").GetComponent<Player>();
        SelfSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (/*Input.GetButtonDown("Enter") && */on_off == true) {
            //AudioSource SFX = SelfSource.GetComponent<AudioSource>();
            //SFX.PlayOneShot(SelfClip, 1f);

            Albert.transform.position = Stand.transform.position;
            Albert.transform.LookAt(LookAt.transform.position);

            //Albert.GetComponent<Animator>().SetTrigger("Heal");
            //NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 0f;
            Player.GetComponent<PlayerMove>().enabled = false;
            Player.GetComponent<Input_Handler>().enabled = false;
            Door.GetComponent<BoxCollider>().enabled = false;
            Icon.SetActive(false);
            Destroy(IconCollider);
            count = true;
        }

        if (count == true) {
            foreach (GameObject A in Bug) {
                A.SetActive(true);
            }
            time += 1 * Time.deltaTime;
            darkness += 5f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
            NewerUI.SetActive(false);
        }

        if (time >= 0.8f) {
            PlayerCamera.transform.position = CameraObj.transform.position;
            PlayerCamera.GetComponent<Camera>().enabled = false;
            darkness -= 8f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
            Camera.SetActive(true);
            gameObject.GetComponent<Animator>().SetTrigger("Open");
            count = false;
        }

        if (fade == true) {
            darkness += 5f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
        }
	}

    public void Out() {
        on_off = false;
        //NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 1f;
        Player.GetComponent<PlayerMove>().enabled = true;
        Player.GetComponent<Input_Handler>().enabled = true;
        Door.GetComponent<BoxCollider>().enabled = true;
        foreach (GameObject A in Bug) {
            Destroy(A);
        }
        Destroy(Camera);
        PlayerCamera.GetComponent<Camera>().enabled = true;
        darkness = 0f;
        Black.SetActive(false);
        NewerUI.SetActive(true);
        foreach (GameObject A in EndObj) {
            A.SetActive(true);
        }
        Destroy(gameObject);
    }

    public void FadeOut() {
        darkness = 0;
        time = 0;
        fade = true;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            on_off = true;
            Albert.GetComponent<Animator>().SetTrigger("ShowBug");
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }

    /*void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            on_off = false;
        }
    }*/
}
