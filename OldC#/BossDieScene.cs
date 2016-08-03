using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace Boss {
public class BossDieScene : MonoBehaviour {
		public BasicBoss A;
		public BasicBoss B;
		bool C=false;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
			if(A.hp<=0&&B.hp<=0&&C==false){
				SceneManager.LoadSceneAsync("video");
				C = true;
				Screen.lockCursor = false;
			}
	}
}
}
