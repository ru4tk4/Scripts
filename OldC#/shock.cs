using UnityEngine;
using System.Collections;

public class shock : MonoBehaviour {
	public float Punchtime = 1f;
	public Vector3 aa = new Vector3 (0,0,3f);
	public float MaxDistance;
	// Use this for initialization
	void Start () {
        /*float Distance = Vector3.Distance(transform.position, GameObject.Find("Albert2").transform.position);
        float kk = MaxDistance - Distance;
        if (kk < 0)
            kk = 0;
        aa = aa * (kk / MaxDistance);*/
        
  
        Hashtable wrd1 = new Hashtable();
        wrd1.Add("amount", aa);
        wrd1.Add("islocal", true);
        wrd1.Add("time", Punchtime);
        GameObject.Find("PlayerCamera").transform.localPosition = new Vector3(0, 0, 0);
        iTween.ShakePosition(GameObject.Find("PlayerCamera"), wrd1);
        ///

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
