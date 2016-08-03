using UnityEngine;
using System.Collections;
//關門放狗
public class DoorOpenTime : MonoBehaviour
{
    public Animator DoorAni;
    public float OpenTime;
    public GameObject[] monster;
    public GameObject[] monsterhere;
    public int MonsterAmount;
    public float monsterTimr;

    bool Enterdoor;
    int monsterNumder;
    bool off;
    // Use this for initialization
    void Start()
    {
        //DoorAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Enterdoor==true)
        {
            
        }*/
    }

    IEnumerator DoorIE(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        DoorAni.SetBool("OpenTime", true);
        off = true;

    }

    IEnumerator MonsterIE(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject effect = Instantiate(monster[Random.Range(0, 2)], monsterhere[Random.Range(0, 2)].transform.position, monsterhere[Random.Range(0, 2)].transform.rotation) as GameObject;
        monsterNumder++;
        if (off == false)
        {
            StartCoroutine(MonsterIE(monsterTimr));
        }
    }

    void OnTriggerEnter(Collider other1)
    {
        if (other1.tag == "Player" && Enterdoor == false)
        {
            Enterdoor = true;
            StartCoroutine(DoorIE(OpenTime));
            StartCoroutine(MonsterIE(monsterTimr));
        }

    }

}
