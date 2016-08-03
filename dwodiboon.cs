using UnityEngine;
using System.Collections;

public class dwodiboon : MonoBehaviour {
    public GameObject Effect1;
    public int i;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    int ii;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boss")
        {
            GameObject Effect = Instantiate(Effect1, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
        }
        if (ii > i)
        {
            GameObject Effect = Instantiate(Effect1, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
            
        }
        ii++;

    }

}
