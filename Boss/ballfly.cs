using UnityEngine;
using System.Collections;

public class ballfly : MonoBehaviour {
    Vector3 inder;
    Transform player;
    public float speed;
    public float rotaspeed;
    public float mind=2;
    Rigidbody obj;
	// Use this for initialization
	void Start () {

        obj = GetComponent<Rigidbody>();
        player = GameObject.Find("Albert2").transform;

	}


    void Update()
    {
        inder = new Vector3(player.position.x, player.position.y+0.6f, player.position.z);
        if (Vector3.Distance(transform.position,inder)>mind)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inder - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotaspeed * Time.deltaTime);
        }
        obj.AddForce(gameObject.transform.forward * speed);
    }

}
