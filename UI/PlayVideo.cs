using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour
{

    public MovieTexture Video;

	void Start ()
    {
        GetComponent<RawImage>().texture = Video as MovieTexture;
        Video.Play();
        Video.loop = true;
    }
	
	void Update ()
    {
	}
}
