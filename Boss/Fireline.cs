using UnityEngine;
using System.Collections;

public class Fireline : MonoBehaviour {
    public float LTime;
    public int lv;
    public float dis;
    public GameObject fire;
    public GameObject att;

    Vector3 a;
    
	// Use this for initialization
	void Start () {
        //StartCoroutine(checkRangeAttackTime(LTime));
        a = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(a, transform.position) > dis)
        {
            GameObject bulle = Instantiate(fire, transform.position, transform.rotation) as GameObject;
            a = transform.position;
            lv -= 1;
            if (lv <= 0)
            {
                gameObject.transform.parent = bulle.transform;
                Destroy(this);
                Destroy(att);
            }
        }
        


	}
    IEnumerator checkRangeAttackTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject bulle = Instantiate(fire, transform.position,transform.rotation) as GameObject;
        lv -= 1;
        if(lv <= 0)
        {
            gameObject.transform.parent = bulle.transform;
            Destroy(this);
            Destroy(att);
        }

        StartCoroutine(checkRangeAttackTime(LTime));
        ;

    }
}
