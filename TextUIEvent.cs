using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class TextUIEvent : MonoBehaviour
{

	public string[] txt ;
	public Text TextUI;
    public float TextTime;
	public bool OnOff ;
    
	float list=0;
    private int ArrTime =0;
    private int ArrLength;
    private int[] Arrnum;
    // Use this for initialization
    void Start () {
        TextUI = gameObject.GetComponent<UnityEngine.UI.Text>();
    }
	
	// Update is called once per frame
	public float darkness = 0;
	void Update () {

		if (OnOff == true) {
			if(darkness < 1){
			 
				//darkness += 1.5f *Time.deltaTime; 
				//TextUI.color = new Vector4(255,255,255, Mathf.Clamp(darkness, 0, 1));
              
            }
            else
            {

            }
		}
         
		if (OnOff == false) {
			if(darkness > 0){
			
				darkness += -0.5f *Time.deltaTime; 
				TextUI.color = new Vector4(255,255,255, Mathf.Clamp(darkness, 0, 1));
            }
            else
            {

                if (ArrLength > 0)
                {
                    ArrTime++;
                    ArrLength--;
                    TextUI.text = txt[Arrnum[ArrTime]];
                    OnOff = true;
                    StartCoroutine(checkTextTime(TextTime));
                }
            }
		}

	}

    IEnumerator checkTextTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
      
        OnOff = false;


    }

    
    public void TextOn (int[] number){
        Arrnum = number;
        ArrTime = 0;
        ArrLength = number.Length-1;
        TextUI.text = txt[number[ArrTime]];
        
        OnOff = true;
        StartCoroutine(checkTextTime(TextTime));
    }


	void TextOff (){

	}











}