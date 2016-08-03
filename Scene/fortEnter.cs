using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fortEnter : MonoBehaviour {
    static public bool fortopen = false;
    public float Opentime;
    float GOtime;
    public Image CountUI;
    public Animator C;
    public Animator S;
    public Text tex;
    public GameObject ON;
    int count;

    void Start ()
    {
        GOtime = Opentime;
	}


	void Update ()
    {

        CountUI.fillAmount = GOtime / 5;
        count = (int)GOtime;
        tex.text = count.ToString();

        if (GOtime <= 0)
        {
            fortopen = true;
            ON.GetComponent<Animator>().SetBool("On",true);
            S.SetBool("On",true);
            GOtime = 0;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (NewerUI.Gamepaused == false)
            {
                tex.GetComponent<CanvasGroup>().alpha = 1;
                C.SetBool("Stay", true);
                GOtime -= 1 * Time.deltaTime;
            }
        }

    }
    
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            if (NewerUI.Gamepaused == false)
            {
                tex.GetComponent<CanvasGroup>().alpha = 0;
                fortopen = false;
                GOtime = Opentime;
                C.SetBool("Stay", false);
                S.SetBool("On", false);
                ON.GetComponent<Animator>().SetBool("On", false);
            }
        }

    }
    
}
