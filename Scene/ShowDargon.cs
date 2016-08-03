using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowDargon : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject PassCamera;
    public GameObject NewerUI;
    public GameObject Black;
    public GameObject Boss;
    public GameObject BossHP;
    public GameObject Cube;
    public GameObject Cube2;

    bool on_off = false;
    float darkness = 0f;
    float count = 0f;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (darkness >= 255)
        {
            darkness = 255;
        }
        if (darkness <= 0f)
        {
            darkness = 0f;
        }

        if (on_off == true)
        {
            Player.GetComponent<PlayerMove>().enabled = false;
            Player.GetComponent<Input_Handler>().enabled = false;
            NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 0f;
            count += 1f * Time.deltaTime;
            darkness += 3f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
            NewerUI.SetActive(false);
        }

        if (count >= 1f)
        {
            PlayerCamera.SetActive(false);
            PassCamera.SetActive(true);
            darkness -= 8f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
        }

        if (count >= 2f)
        {
        }

        if (count >= 9f)
        {
            darkness += 8f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
        }

        if (count >= 10f)
        {
            on_off = false;
            Player.GetComponent<PlayerMove>().enabled = true;
            Player.GetComponent<Input_Handler>().enabled = true;
            NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 1f;
            Destroy(PassCamera);
            PlayerCamera.SetActive(true);
            NewerUI.SetActive(true);
            Boss.SetActive(true);
            BossHP.SetActive(true);
            Cube.SetActive(true);
            Cube2.SetActive(true);
            Destroy(Black);
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            on_off = true;
        }
    }
}
