using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour
{
    public GameObject bullesEX;
    public Animator anim;
    public Animator Alce;
    public Animator ReloadUI;
    //public GameObject A;
    public GameObject Guneye;
    public GameObject C;
   
    public GameObject bulles;
	public GameObject bullesFire;
	public GameObject firehere;
    public GameObject ReLoad;
    public GameObject Reloadhere;
    public Transform target;
	public Vector3 IKFollow;
    public Transform IKFollowStart;
    public Transform IKFollowGo;
    public Transform IKFollowMin;
    public float Smooth;
	public float cameraSmooth;
	float fire_CD_Time;
	
    public float ShildV;
    


	public Animator GunAnim;
	public GameObject GunUI;
	public GameObject GunUI01;
	public GameObject FireUI00;
	public GameObject Effect2;

    private Input_Handler InputAtt;
    private Player player;
    public Transform IK_Hand;//IK手 
    static public bool GunfireV;
    
    public RootMotion.FinalIK.Demos.HitReaction Hit;

    bool re = false;
    bool over = false;
    static public bool lockWait = false;

    // Use this for initialization
    void Start () {
        InputAtt = gameObject.GetComponent<Input_Handler>();
        player = gameObject.GetComponent<Player>();
        Hit = gameObject.GetComponent<RootMotion.FinalIK.Demos.HitReaction>();
       
    }
	

	void Update () {
        
       // gunmove();
        Ray();
        locking();
        if (deviation > 0.001)
        {
            deviation -= deviation * Time.deltaTime;
        }
        else
        {
            deviation = 0;
        }
        // GunChange ();
        /* AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
         if ( currentState.fullPathHash == Animator.StringToHash("Base Layer.Hurt"))
         {
             print("Hu");
         }*/

        if (Input.GetButton("Re")&&re==false)
        {
            re = true;
            StartCoroutine(checkRangeAttackTime(player.reloadTime));
            GunAnim.SetFloat("Gunchange", -1);
            GameObject reload = Instantiate(ReLoad, Reloadhere.transform.position, Reloadhere.transform.rotation) as GameObject;
            Alce.SetTrigger("Reload");
            ReloadUI.SetTrigger("Reload");
        }

        if (Input.GetKeyDown(KeyCode.F) && over == false)
        {
            player.energy += 200;
           /* over = true;
            StartCoroutine(OverTime(50f));
            Player.ShiledTimes += 10;*/
        }





    }


    /*public void GunChange()
	{
		
		if (Input.GetButton("Fire2"))
		{
			GunOn();
		}
		else
		{
			GunOff();
		}
		
	}*/


    public GameObject[] MazUI;
    public GameObject MazTex;
    public GameObject Weapon1;
    public GameObject Weapon2;

    void locking()
    {
       
        AnimatorStateInfo currentStateAnim = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetButton("Fire2")  /*&& currentStateAnim.fullPathHash != Animator.StringToHash("Base Layer.Attack")*/ && anim.GetInteger("Attack1_Num") ==0 && lockWait == false)
        {
           


            MazUI[player.WD_number].SetActive(true);
            
            MazTex.SetActive(true);
            GunOn();
            float distance = Vector3.Distance(target.position, IKFollowGo.transform.position);
            C.transform.position = Vector3.Lerp(C.transform.position, Guneye.transform.position, cameraSmooth * Time.deltaTime);
            IKFollow = Vector3.Lerp(IKFollow, IKFollowGo.transform.position, Smooth * Time.deltaTime);
            //近距離瞄準
            /*if (distance>1) {
                IKFollow = Vector3.Lerp(IKFollow, IKFollowGo.transform.position, Smooth * Time.deltaTime);
            }
            else
            {
                IKFollow = Vector3.Lerp(IKFollow, IKFollowMin.transform.position, Smooth * Time.deltaTime);
            }*/
            Quaternion Camerarot = Quaternion.Euler(gameObject.transform.rotation.x, Camera.main.transform.eulerAngles.y, gameObject.transform.rotation.z);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Camerarot, Smooth * Time.deltaTime);
            FireAtt();
            GunModelChange();

        }
        else
        {
            foreach (GameObject A in MazUI)
            {
                A.SetActive(false);
            }
            MazTex.SetActive(false);
            GunOff();
            GunModelChange();
            //C.transform.position = Vector3.Lerp(C.transform.position, A.transform.position, cameraSmooth * Time.deltaTime);
        }
        ShildV = gameObject.GetComponent<Player>().energy;
    }


    void Ray()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(target.position, target.forward, out hit,5000f, 1023))
        {
            //Debug.DrawLine(target.position, target.forward ,Color.green);
            
                IKFollowGo.transform.position = Vector3.Lerp(IKFollowGo.transform.position, hit.point, Smooth * Time.deltaTime);
            
        }
    }


	void FireRay(GameObject buttonforward)
	{
		RaycastHit hit;
		if (Physics.Raycast (buttonforward.transform.position, buttonforward.transform.forward, out hit, 1)) {
			if (hit.collider.tag == "Box") {
				GameObject effect = Instantiate (Effect2, hit.point, hit.transform.rotation) as GameObject; //creating the effect
				print ("2");
				effect.transform.parent = hit.collider.transform;
				
			}

		}
	}

	public void GunOn() {
        InputAtt.currentState = Player.State.Aim;
        PlayerMove.SightSwitch = true;
        IKSwitch();
        //anim.SetBool("Run", false);
        FireUI00.SetActive(true);
        GunUI.SetActive(true);
		GunUI01.SetActive(true);
        //Weapon1.SetActive(false);
        Weapon1.transform.localPosition = Vector3.Lerp(Weapon1.transform.localPosition, new Vector3(100, Weapon1.transform.localPosition.y),10 * Time.deltaTime);
        
        Weapon2.SetActive(true);
	}
	//關閉槍模式
	public void GunOff() {
        InputAtt.currentState = Player.State.Idle;
        PlayerMove.SightSwitch = false;       
		GunModelChange();
		IKSwitch();
        //Weapon1.SetActive(true);
        Weapon1.transform.localPosition = Vector3.Lerp(Weapon1.transform.localPosition, new Vector3(1460, Weapon1.transform.localPosition.y), 10 * Time.deltaTime);
        Weapon2.SetActive(false);
        FireUI00.SetActive(false);
		GunUI.SetActive(false);
		GunUI01.SetActive(false);
	} 
	
	//IK開關
	public void IKSwitch(){
		if (PlayerMove.SightSwitch == false)
		{
			//gameObject.GetComponent<RootMotion.FinalIK.AimIK>().enabled = false;
			gameObject.GetComponent<RootMotion.FinalIK.Demos.SimpleAimingSystem>().enabled = false;
		}
		else
		{
			//gameObject.GetComponent<RootMotion.FinalIK.AimIK>().enabled = true;
			gameObject.GetComponent<RootMotion.FinalIK.Demos.SimpleAimingSystem>().enabled =true;
		}
	}
    public void IKon(bool on)
    {       
            gameObject.GetComponent<RootMotion.FinalIK.Demos.SimpleAimingSystem>().enabled = on;   
    }

    

    public void GunModelChange(){
		if (PlayerMove.SightSwitch == false)
		{
			GunAnim.SetFloat ("Gunchange", 1);
			
		}else{
			GunAnim.SetFloat ("Gunchange", 0);
		}
	}


   

    


    public void WpchangeReload()
    {
        if (Magazine == player.Magazine)
        {
            StartCoroutine(checkRangeAttackTime(player.reloadTime));
        }
    }

    public Animator AlceCross;
    public int Magazine;
    public GameObject sword;
    float deviation = 0;
    public float stable = 0.01f;
    Vector3 ran;
    public void FireAtt() {
        AnimatorStateInfo currentStateAnim = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetButton("Fire1")&& ShildV > 0 && PlayerMove.SightSwitch == true && currentStateAnim.fullPathHash != Animator.StringToHash("Base Layer.Hurt") 
            && gameObject.GetComponent<RootMotion.FinalIK.Demos.SimpleAimingSystem>().enabled == true&& Magazine < player.Magazine && fortEnter.fortopen == false&& re == false)
		{

            //IKFollow = IKFollowGo.transform.position;
            //if (IKFollow == IKFollowGo.transform.position)
            // {
            GunfireV = true;
            if (Time.time > fire_CD_Time) {
                // firehere.transform.LookAt(IKFollow);


                if (Player.Alce == true /*&& player.Alce_on_off == true*/)
                {
                    AlceCross.SetTrigger("Open");
                }

                ran = new Vector3(Random.Range(deviation, -deviation), Random.Range(deviation, -deviation), Random.Range(deviation, -deviation));
                

                GameObject kkk = Instantiate(bullesFire, firehere.transform.position, firehere.transform.rotation) as GameObject;
                GameObject bulle = Instantiate(bulles, firehere.transform.position, firehere.transform.rotation) as GameObject;
                bulle.transform.forward = firehere.transform.forward+ran;
                bulle.GetComponent<Rigidbody>().AddForce((firehere.transform.forward+ran) * player.BulletSpeed);
                Hit.FireGoo();
                
                if (over == false)
                {
                    fire_CD_Time = Time.time + player.fire_CD;
                    Magazine++;
                    player.energy-= player.Gunlost;

                }
                else
                {
                    //Magazine++;
                    fire_CD_Time = Time.time + (player.fire_CD*0.1f);
                }
               
                if(deviation < 0.1)
                deviation += stable;
                
				//FireRay(bulle);
                if (Magazine == player.Magazine)
                {
                    re = true;
                    StartCoroutine(checkRangeAttackTime(player.reloadTime));
                    GunAnim.SetFloat("Gunchange", -1);
                    GameObject reload = Instantiate(ReLoad, Reloadhere.transform.position, Reloadhere.transform.rotation) as GameObject;
                    Alce.SetTrigger("Reload");
                    ReloadUI.SetTrigger("Reload");
                    //sword.GetComponent<Shader>(). = new Color(255f, 0f, 0f, 60f);
                }
             }
        }
        else
        {
             GunfireV = false;

        }
		
	}

    IEnumerator checkRangeAttackTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        re = false;
        Magazine = 0;
        GunAnim.SetFloat("Gunchange", 0);

    }

    IEnumerator OverTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        over = false;

    }
    private IEnumerator coroutine;
    IEnumerator lockWaitTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // print("ccccc");
        lockWait = false;

    }

    public void LockWaitVoid(float waitTime)
    {

        lockWait = true;
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = lockWaitTime(waitTime);
        StartCoroutine(coroutine);
    }

}