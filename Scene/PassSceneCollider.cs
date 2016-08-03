using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PassSceneCollider : MonoBehaviour {

    private NewerUI NewerUI;
    public Image Black;
    public GameObject Player;
    public GameObject Camera;
    public GameObject CameraObj;

    bool image_on = false;
    float darkness = 0;

    void Start() {
        NewerUI = GameObject.Find("Newer_UI").GetComponent<NewerUI>();
    }

    void Update() {
        if (image_on == true) {
            darkness += 1f * Time.deltaTime;
            Black.color = new Vector4(255, 255, 255, Mathf.Clamp(darkness, 0, 1));
            Camera.GetComponent<Camerainto>().enabled = true;
        }
        if (darkness >= 255f) {
            image_on = false;
            darkness = 0f;
            Camera.transform.position = new Vector3(CameraObj.transform.position.x, CameraObj.transform.position.y, CameraObj.transform.position.z);
            Camera.GetComponent<Camerainto>().here = CameraObj;
            NewerUI.Ani_albert.speed = 0f;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {            
            image_on = true;
        }
    }
}
