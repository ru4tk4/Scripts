using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LLLLLL : MonoBehaviour {
    static public float E;
    static public float M;

    public Text EU;
    public Text MU;
    // Use this for initialization
    void Start ()
    {      
	}
    
	// Update is called once per frame
	void Update ()
    {
        show();
    }

    void show()
    {
        EU.text = E.ToString();
        MU.text = M.ToString();
    }
}
