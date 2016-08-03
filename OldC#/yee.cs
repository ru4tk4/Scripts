using UnityEngine;
using System.Collections;

public class yee : MonoBehaviour {
    Vector2 F;
    Vector3 K;
	// Use this for initialization
	void Start () {
        K = gameObject.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        // gameObject.transform.position =new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + Random.insideUnitCircle * 5;
        F = Random.insideUnitCircle * 10;
        gameObject.transform.position = new Vector3(K.x+F.x, gameObject.transform.position.y, K.z+F.y);
    }
}
