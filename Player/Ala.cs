using UnityEngine;
using System.Collections;

public class Ala : MonoBehaviour
{
	static public bool swordenter = false ;

	

	public Animator anim;
	static public int attacklevel;
	public GameObject[] swordEffect;

	public GameObject[] heres;
	static public GameObject[] heresST;
	public GameObject[] swardeffect ;


    

    private void Awake() {
        //Screen.lockCursor = true;//影藏滑鼠
        heresST = heres;
		anim = GetComponent<Animator>();			
		

	}


	public void Update(){
        
        
       
    }


   


    public void SwordaniEND (){
		//GameObject.Find("PlayerCamera").GetComponent<UnityStandardAssets.ImageEffects.MotionBlur> ().enabled = false;
		//GameObject.Find("PlayerCamera").GetComponent<UnityStandardAssets.ImageEffects.BloomAndFlares>().enabled = false;
		Time.timeScale = 1F;    //  速度变为原来；
		Time.fixedDeltaTime = 0.02F*Time.timeScale;
		swordenter = false;

		
	}


	public void Swordaniplaying(int attlv){
		attacklevel = attlv;
		swordenter = true;
       
    }


    public void  AttackEffect(int level){	 

		GameObject effect =  Instantiate(swordEffect[level],heres[level].transform.position, heres[level].transform.rotation) as GameObject ; //creating the effect
		effect.transform.parent = heres[level].transform;
       // Debug.Break();

    }











}


