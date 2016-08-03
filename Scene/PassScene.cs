using UnityEngine;
using System.Collections;

public class PassScene : MonoBehaviour {

    public GameObject UI;
    public Animator Albert;
    public GameObject Cam;
    public GameObject PlayerCam;
    public GameObject PointCollider;
    
	// Use this for initialization
	void Start ()
    {
        Albert.SetBool("Pass1", true);
        MouseRotation.camoff = false;
        Screen.lockCursor = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OpenSc()
    {
        MouseRotation.camoff = true;
        gameObject.GetComponent<GunFire>().enabled = true;
        gameObject.GetComponent<Input_Handler>().enabled = true;
        gameObject.GetComponent<Player>().enabled = true;
        gameObject.GetComponent<PlayerMove>().enabled = true;
        //Cam.GetComponent<MouseRotation>().enabled = true;
        PlayerCam.GetComponent<Camerainto>().here = Cam; ;
        Invoke("count", 2);
        PointCollider.SetActive(true);
        Albert.SetBool("Pass1", false);
        UI.SetActive(true);
       
    }

    void count()
    {
        PlayerCam.transform.position = Cam.transform.position;
        PlayerCam.transform.rotation = Cam.transform.rotation;
        PlayerCam.GetComponent<Camerainto>().enabled = false;
        Destroy(this);
    }
}
