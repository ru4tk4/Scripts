using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextGM : MonoBehaviour
{
    public TextAsset File;
    
    public string[] TextLine;

    void Start()
    {
        if (File != null)
        {
            TextLine = (File.text.Split('\n'));
        }
    }
}
