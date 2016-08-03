using UnityEngine;
using System.Collections;

public class AniGoSpeed : MonoBehaviour {
    public float GoTime;
	// Use this for initialization
	void Start () {
        StartCoroutine(Go(GoTime));
    }
	
	// Update is called once per frame
	

    IEnumerator Go(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        gameObject.GetComponent<Animator>().SetFloat("Speed", 1f);
            
       
    }
}
