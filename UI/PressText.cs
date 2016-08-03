using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PressText : EventData
{
    public TextUIEvent text;
    public int[] num;
    public int[] num1;
    public int[] num2;
    public Animator[] TextAni;
    public GameObject[] PressUI;
    public Animator Door;
    public Animator Door_Obj;
    public PressTextKey[] key;
    public GameObject particle;
    public MeshRenderer Render;
    public GameObject[] Rocks;

    bool on_off = false;
    bool can_not = false;
    bool count = false;
    bool not = false;

    float list = 1;
    float time = 0;

    void Start()
    {
        Render = particle.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (count == true)
        {
            time += 1 * Time.deltaTime;
        }

        if (time >= 1f)
        {
            Door.SetTrigger("Open");
            time = 0;
            Destroy(particle.GetComponent<BoxCollider>());
            Destroy(gameObject);
        }


        if (not == true && Input.GetButtonDown("Enter") && PressTextKey.take < 3)
        {
            PressUI[0].GetComponent<Animator>().SetBool("Open", false);
        }


        if (on_off == true && Input.GetButtonDown("Enter") && PressTextKey.take < 3)
        {
            PressUI[0].SetActive(true);
            PressUI[0].GetComponent<Animator>().SetBool("Open", true);
            text.TextOn(num);
            TextAni[0].SetTrigger("Open");
            not = true;
        }

        if (on_off == true && Input.GetButtonDown("Enter") && PressTextKey.take >= 1 && PressTextKey.take <= 2)
        {
            text.TextOn(num2);
            TextAni[0].SetTrigger("Open");
        }

        /*if (on_off == true && Input.GetKeyDown(KeyCode.E) && PressTextKey.take == 2)
        {
            text.TextOn(num2);
            TextAni[0].SetTrigger("Open");
            list--;
        }*/

        if (on_off == true && Input.GetButtonDown("Enter") && PressTextKey.take >= 3)
        {
            foreach (GameObject A in Rocks)
            {
                A.SetActive(true);
            }
            Render.material.SetColor("_Color", new Color(0, 0.23f, 0.62f, 0f));
            //PressUI[1].SetActive(true);
            Destroy(PressUI[0]);
            text.TextOn(num1);
            Door_Obj.SetTrigger("Open");
            TextAni[0].SetTrigger("Open");
            count = true;
            list--;
            PressTextKey.take = 0;
        }
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player" && list > 0)
        {
            on_off = true;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            if (on_off == true)
            {
                list++;
            }
        }
        on_off = false;
    }
}
