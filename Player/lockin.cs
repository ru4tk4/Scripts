using UnityEngine;
using System.Collections;

public class lockin : MonoBehaviour {

    public RectTransform LockUi;
    public Camera camera;
    // Use this for initialization
    void Start () {
	
        
	}
	
	// Update is called once per frame
	void Update () {
        Ray();
    }

    void Ray()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5000f, 1023))
        {
            //Debug.DrawLine(target.position, target.forward ,Color.green);

            LockUi.position = camera.WorldToScreenPoint(hit.point);

        }
    }
}
