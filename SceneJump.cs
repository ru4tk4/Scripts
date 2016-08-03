using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneJump : MonoBehaviour
{
   
    public float Times;
    float list = 0;
    public PlayerSave PlayerSave;

   // public bool SceneJump;
    public string Scenename;

    
    public Image DarkPanel;
    public GameObject Black;
    private float darkness = 0;
    public bool ON;
    // Use this for initialization
    void Start()
    {
        //DarkPanel = GameObject.Find("Black").GetComponent<Image>();
        PlayerSave = GameObject.Find("Albert2").GetComponent<PlayerSave>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ON == true)
        {
            darkness += 0.9f * Time.deltaTime;
            DarkPanel.color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));

            if (darkness >= 1f)
            {
                PlayerSave.SceneChange(Scenename);
                ON = false;
                Destroy(this);

                

            }
        }
    }

    void OnTriggerEnter(Collider other1)
    {
        if (other1.tag == "Player" && list < Times)
        {
            Black.SetActive(true);
            NewerUI.Gamepaused = true;
            ON = true;        

        }

    }

}