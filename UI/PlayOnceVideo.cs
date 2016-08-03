using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayOnceVideo : MonoBehaviour
{
    public MovieTexture Video;
    public string SceneName;

    public AsyncOperation E;

    float num;

    void Start()
    {
        GetComponent<RawImage>().texture = Video as MovieTexture;
        Video.Play();
        E = SceneManager.LoadSceneAsync(SceneName);
        E.allowSceneActivation = false;
    }

    void Update()
    {
        num += 1 * Time.deltaTime;

        if (num >= 52)
        {
            Video.Stop();
            E.allowSceneActivation = true;
        }
    }
}
