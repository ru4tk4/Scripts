using UnityEngine;
using System.Collections;
using Xft;

public class EffectOpen : MonoBehaviour {

	public GameObject[] Effects;
	public GameObject[] Heres;
	public bool[] stop;
    public GameObject Taril;


	public XWeaponTrail ProTrailDistortL;
	public XWeaponTrail ProTrailShortL;
	public XWeaponTrail ProTraillongL;

	public XWeaponTrail ProTrailDistortR;
	public XWeaponTrail ProTrailShortR;
	public XWeaponTrail ProTraillongR;

	public float smoothly = 0.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EffectOpenEvent(int level){
		
		GameObject effect =  Instantiate(Effects[level],Heres[level].transform.position, Heres[level].transform.rotation) as GameObject ; //creating the effect

		if(stop[level] == true ){
		
			effect.transform.parent = Heres[level].transform;
	
		}
	}

    public void EOE(int level)
    {
        Effects[level].SetActive(true);
        Effects[level].transform.position = Heres[level].transform.position;
        Effects[level].transform.rotation = Heres[level].transform.rotation;
        
        if (stop[level] == true)
        {

            Effects[level].transform.parent = Heres[level].transform;

        }
    }

	public void SwordEffectXWon(int a){
		if(a == 1){
		ProTrailDistortL.Activate();
		ProTrailShortL.Activate();
		ProTraillongL.Activate();
		}
		if (a == 2) {
			ProTrailDistortR.Activate ();
			ProTrailShortR.Activate ();
			ProTraillongR.Activate ();
		}
		}

	public void SwordEffectXWoff(int a){
		if(a == 1){
			ProTrailDistortL.StopSmoothly(smoothly);
			ProTrailShortL.StopSmoothly(smoothly);
			ProTraillongL.StopSmoothly(smoothly);
		}
		if(a == 2){
			ProTrailDistortR.StopSmoothly(smoothly);
			ProTrailShortR.StopSmoothly(smoothly);
			ProTraillongR.StopSmoothly(smoothly);
		}
	}

    public void TrailOn()
    {
        Taril.SetActive(true);
    }

    public void TrailOff()
    {
        Taril.SetActive(false);
    }
	
}
