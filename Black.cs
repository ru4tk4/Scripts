using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Black : MonoBehaviour {
    public Image DarkPanel;
    private float darkness = 0;
    public PlayerSave PlayerSave;
    // Use this for initialization
    void Start () {
        DarkPanel = GameObject.Find("Black").GetComponent<Image>();
        PlayerSave = GameObject.Find("Albert2").GetComponent<PlayerSave>();
      

    }
	
	// Update is called once per frame
	void Update () {
        
        darkness += 0.3f * Time.deltaTime;
        DarkPanel.color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));

        if (darkness >= 0.95f)
        {
            Destroy(this);
            //PlayerSave.SceneChange(Scenename);

        }
    }
}
