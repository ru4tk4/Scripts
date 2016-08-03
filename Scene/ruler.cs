using UnityEngine;
using System.Collections;

public class ruler : MonoBehaviour {
    public float L = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(gameObject.transform.position, Vector3.up * -1, Color.blue);
        Debug.DrawLine(transform.position, transform.position + Vector3.up * -1 * L, Color.green);
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
