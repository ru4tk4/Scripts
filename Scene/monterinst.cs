using UnityEngine;
using System.Collections;

public class monterinst : MonoBehaviour {
    public GameObject monster;
    public GameObject[] monsterhere;
    public float monterTimr;
    // Use this for initialization
    void Start () {
        StartCoroutine(MonsterIE(monterTimr));

    }

    // Update is called once per frame
    void Update () {
	
	}
    IEnumerator MonsterIE(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject effect = Instantiate(monster, monsterhere[Random.Range(0, 2)].transform.position, monsterhere[Random.Range(0, 2)].transform.rotation) as GameObject;
        
       
            StartCoroutine(MonsterIE(monterTimr));
       
    }
}
