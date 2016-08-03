using UnityEngine;
using System.Collections;

public class BossDie : MonoBehaviour {

	public GameObject BossCamare;
	public GameObject player;
	public GameObject boss;
	public int A = 0 ;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BossD (){

		if (A >= 1) {
		
			player.SetActive (false);
			BossCamare.SetActive (true);
			gameObject.GetComponent<Boss.StoneGolemManager>().enabled = false;
		
		} else {
			print (A);
			boss.GetComponent<BossDie>().A++;
		}

	}


}

