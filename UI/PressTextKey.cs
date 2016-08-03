using UnityEngine;
using System.Collections;

public class PressTextKey : MonoBehaviour
{
    static public int take = 0;

    public GameObject UI_Inter;
    public GameObject Obj;
    public GameObject UI;

    bool into = false;
    bool taken = false;
    bool count = false;
    bool ttt = false;

    float num = 0;

    void Update()
    {
        if (ttt == true && taken == true && Input.GetButtonDown("Enter"))
        {
            UI_Inter.GetComponent<Animator>().SetBool("Open", false);
        }

        if (into == true && Input.GetButtonDown("Enter"))
        {
            take += 1;
            UI.SetActive(false);
            UI_Inter.SetActive(true);
            UI_Inter.GetComponent<Animator>().SetBool("Open", true);
            Destroy(Obj);
            count = true;
            taken = true;
            ttt = true;
        }

        if (count == true)
        {
            num += 1 * Time.deltaTime;
        }

        if (num >= 6f)
        {
            UI_Inter.GetComponent<Animator>().SetBool("Open", false);
            Destroy(gameObject , 2.5f);
        }
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            into = true;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            into = false;
        }
    }
}
