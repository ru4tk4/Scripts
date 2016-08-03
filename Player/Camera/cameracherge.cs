using UnityEngine;
using System.Collections;
//未使用參考用

public class cameracherge : MonoBehaviour {
	public float Smooth;
	bool GO;
	public Animator playerAni;

	// Use this for initialization



	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		 
		/*AnimatorStateInfo currentState = playerAni.GetCurrentAnimatorStateInfo(0);
		if (currentState.nameHash == Animator.StringToHash("Base Layer.Sword_to_Gun") | currentState.nameHash == Animator.StringToHash("Base Layer.RunDirection"))
		{*/

			if (PlayerMove.SightSwitch == true) {
				//紀錄位置

				//	Camerarotation = fps.playercamera.transform.rotation;
				//平滑移動角度及位置
				GameObject.Find ("Main Camera").transform.position = Vector3.Lerp (GameObject.Find ("Main Camera").transform.position, transform.position, Smooth * Time.deltaTime);
				GameObject.Find ("Main Camera").transform.rotation = Quaternion.Slerp (GameObject.Find ("Main Camera").transform.rotation, transform.rotation, Smooth * Time.deltaTime);
			} /*else {
				if (PlayerMove.SightSwitch == false) {
					//平滑移動角度及位置
					GameObject.Find ("Main Camera").transform.position = Vector3.Lerp (GameObject.Find ("Main Camera").transform.position, fps.CameraHear.transform.position, Smooth * Time.deltaTime);
					GameObject.Find ("Main Camera").transform.rotation = Quaternion.Slerp (GameObject.Find ("Main Camera").transform.rotation, fps.CameraHear.transform.rotation, Smooth * Time.deltaTime);
				}
			}*/

		//}

	}

}
