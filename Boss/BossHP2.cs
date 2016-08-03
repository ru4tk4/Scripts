using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHP2 : MonoBehaviour
{
    public Image Bar;
    public float MaxHp;
    private Boss.BasicBoss Boss;
    public Boss.BossHP BossHP;
    public string BossName;

    public float TypeA;
    public float TypeB;
    public float TypeC;

    float CopyHP;

	// Use this for initialization
	void Start ()
    {
        Boss = GameObject.Find(BossName).GetComponent<Boss.BasicBoss>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Bar.fillAmount = Boss.hp / MaxHp;
        /*CopyHP = Boss.hp;

        if (Boss.hp >= 10000)
        {
            Boss.hp = 10000;
            BossHP.change = false;
        }

        if (BossHP.change == true)
        {
            if (Boss.hp - CopyHP >= 500)
            {
                CopyHP += 100;
            }
            else if (Boss.hp - CopyHP >= 300)
            {
                CopyHP += 50;
            }
            else if (Boss.hp - CopyHP >= 100)
            {
                CopyHP += 10;
            }
            else if (Boss.hp - CopyHP >= 50)
            {
                CopyHP += 1;
            }
        }
        */
        if (Boss.hp <= TypeA)
        {
            gameObject.GetComponent<Image>().color = new Color(255, 153, 0, 15);
        }
        if (Boss.hp <= TypeB)
        {
            gameObject.GetComponent<Image>().color = new Color(255, 37, 0, 15);
        }
        if (Boss.hp <= TypeC)
        {
            gameObject.GetComponent<Image>().color = new Color(255, 0, 0, 15);
        }

        if (Boss.hp > TypeC)
        {
            gameObject.GetComponent<Image>().color = new Color(255, 37, 0, 15);
        }
        if (Boss.hp > TypeB)
        {
            gameObject.GetComponent<Image>().color = new Color(255, 153, 0, 15);
        }
        if (Boss.hp > TypeA)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 255, 2, 200);
        }
	}
}
