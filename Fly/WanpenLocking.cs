using UnityEngine;
using System.Collections;

public class WanpenLocking : MonoBehaviour {
    public Transform[] mosters;
    public Transform[] targets = {null,null};
    public Transform[] ATTtargets = { null, null};
    public float viewAngle = 20.0f; // 尋敵角度
    public float viewDis = 8.0f;  // 尋敵距離

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        foreach (Transform moster in mosters)
        {
            Ray(moster);
        }
    }

    bool BBB(bool KKK)
    {
        return true;
    }

    void Ray(Transform Target)
    {
        Transform fire = transform;
        fire.LookAt(Target);
        
        RaycastHit hit;

        if (Physics.Raycast(fire.position, fire.forward, out hit))
        {

            if (hit.collider.tag == "Locking")
            {
                if(targets[0] == Target)
                {

                }
                targets[0] = Target;
            }
            else
            {

            }
        }
        else
        {

        }
    }


}
