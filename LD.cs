using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LD : MonoBehaviour {
    public string SceneName;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ST_Game()
    {
        PlayerPrefs.SetInt("Open",0);
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
    }


    public void LD_Game()
    {
        PlayerPrefs.SetInt("GO", 1);
        string S = PlayerPrefs.GetString("SaveNow");
        SceneManager.LoadSceneAsync( S,LoadSceneMode.Single);
    }

    public void EX_Game()
    {
        Application.Quit();
    }
}
