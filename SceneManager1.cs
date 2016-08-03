using UnityEngine;
using System.Collections;

public class SceneManager1 : MonoBehaviour {
	Game.GameManager gameManager;
	public GameObject loaderGameManager;

	void Start() {
			gameManager = GetComponent<Game.GameManager>();
	}
	
	public void ChangeSceneStart(string sceneName) {
		loaderGameManager.GetComponent<Animator>().SetInteger("Show", 1);
		StartCoroutine(SceneAnimWaitStartTime(sceneName));	
	}
	
	public void ChangeSceneEnd() {
		loaderGameManager.GetComponent<Animator>().SetInteger("Show", -1);
		StartCoroutine(SceneAnimWaitEndTime());
	}
	
	private IEnumerator SceneAnimWaitStartTime(string sceneName) {
		yield return new WaitForSeconds(2);
		gameManager.SceneLoad(sceneName, true);
	}
	
	
	private IEnumerator SceneAnimWaitEndTime() {
		yield return new WaitForSeconds(1);
		gameManager.async.allowSceneActivation = true;
	}
}
