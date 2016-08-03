using UnityEngine;
using System.Collections;

namespace Game {
	public class BasicGame : MonoBehaviour {
		public UnityEngine.AsyncOperation async = null;
		public bool sceneDone = false;
		
		/// <summary>
		/// Loads a new scene by name. A flag indicating if the load must be async can be informed.
		/// </summary>
		/// <param name="p_name"></param>
		/// <param name="p_async"></param>
		/// <param name="p_args"></param>
		public void SceneLoad(string p_name,bool p_async) {
			if (p_async) { StartCoroutine(SceneLoadAsync(p_name)); }
			else
			{
				Application.LoadLevel(p_name);
			}
		}
		
		
		private IEnumerator SceneLoadAsync(string p_name) {
			async = Application.LoadLevelAsync(p_name);
			async.allowSceneActivation = false;
			sceneDone = false;
			GameObject gameObject = this.gameObject; 
			
			while (!async.isDone) {
				Debug.Log(async.progress);
				
				if (!sceneDone && async.progress >= 0.89f) {
					sceneDone = true;
					gameObject.SendMessage("ChangeSceneEnd");
				}
				yield return null;
			}
			
			yield return async;
		}
		
	}
}
