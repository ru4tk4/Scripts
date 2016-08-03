using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class TextEvent : EventData {

	public string txt = "請輸入文字";
	public Text TextUI;
	public bool OnOff ;

	float list=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public float darkness = 0;
	void Update () {

		if (OnOff == true) {
			if(darkness < 1){
			
				darkness += 1.5f *Time.deltaTime; 
				TextUI.color = new Vector4(255,255,255, Mathf.Clamp(darkness, 0, 1));
			}
		} 
		if (OnOff == false) {
			if(darkness > 0){
			
				darkness += -0.5f *Time.deltaTime; 
				TextUI.color = new Vector4(255,255,255, Mathf.Clamp(darkness, 0, 1));
			}
		}

	}
	
	
	void OnTriggerEnter(Collider other1) {
		if (other1.tag == "Player") {
			print("1");
			TextUI.text = txt;
			OnOff = true;
			//list++;
		
		} 
		
	}

	void OnTriggerExit(Collider other1) {
		if (other1.tag == "Player") {
			print("2");
			OnOff = false;
			//list++;

		} 
		
	}


	void TextOn (){

	}


	void TextOff (){

	}











}