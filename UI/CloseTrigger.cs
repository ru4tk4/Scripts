using UnityEngine;
using System.Collections;

public class CloseTrigger : MonoBehaviour {

    public Animator UI;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.GetComponent<BigHeal>().num >= 5f)
        {
            CloseUI();
            Destroy(this);
        }
	}

    public void CloseUI()
    {
        UI.SetTrigger("Close");
    }
}
