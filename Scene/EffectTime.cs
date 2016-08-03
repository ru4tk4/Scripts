using UnityEngine;
using System.Collections;

public class EffectTime : MonoBehaviour {
    public float atime;
	// Use this for initialization
	void Start () {
        Invoke("A", atime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void A()
    {
        gameObject.SetActive(false);
    }
}
