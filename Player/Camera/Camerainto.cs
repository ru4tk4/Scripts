using UnityEngine;
using System.Collections;

public class Camerainto : MonoBehaviour {

	public GameObject here;
	public GameObject Guneye;
    public float Smooth;
    public float LestTime;
    public bool Map;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if(Map == true)
        {
           gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, here.transform.eulerAngles.y, gameObject.transform.rotation.z);
        }
        else if (PlayerMove.SightSwitch == false)
        {
			iTween.MoveUpdate (gameObject, here.transform.position, LestTime);
			iTween.RotateUpdate (gameObject, here.transform.eulerAngles, LestTime);
            
           
            //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, here.transform.rotation, Smooth * Time.deltaTime);
            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, here.transform.position, Smooth * Time.deltaTime);
        } else {
			//iTween.MoveUpdate (gameObject, Guneye.transform.position, LestTime);
			//iTween.RotateUpdate (gameObject, Guneye.transform.eulerAngles, LestTime);
		
		}
	}

    public void DDD()
    {
        Destroy(this);
    }
}
