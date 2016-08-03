using UnityEngine;
using System.Collections;

public class Punchtext : MonoBehaviour {
	public Vector3 cc = new Vector3 (0,0.1f,0);
	public Vector3 bb = new Vector3 (0,0.1f,0);
	public Vector3 aa = new Vector3 (0,0.1f,0);
	public GameObject camera;
	public float smooth = 5;
	float fire_CD_Time;
	public float fire_CD = 1;
	public float Punchtime = 1f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp (transform.position, camera.transform.position, Time.deltaTime * smooth);

		if (Time.time > fire_CD_Time) {
			fire_CD_Time = Time.time + fire_CD;
			//iTween.PunchPosition(gameObject, cc, Punchtime);
			//iTween.PunchPosition(gameObject, aa, Punchtime);
			//iTween.PunchRotation(gameObject, bb, 1);
		}
	}
}
