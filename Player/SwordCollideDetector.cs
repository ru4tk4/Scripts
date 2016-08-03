using UnityEngine;
using System.Collections;

public class SwordCollideDetector : MonoBehaviour {
	private JSONObject damageData;
	public Input_Handler inputHandler;
	public int damage = 20;
	public bool goAttack = false;
	public Animator playercameraAni;
	public GameObject swordMark;
	public float Punchtime = 1f;
	public Vector3 aa = new Vector3 (0,0,3f);
    private Player player;
    private Ala ala;


    //public GameObject here1;

    // Use this for initialization
    public SwordCollideDetector (Ala level){

	}
	void Update(){
        
        Gunmodle ();

	}


	void Start () {
        /*TextAsset bindata= Resources.Load("JSON/damageData") as TextAsset;
		damageData = new JSONObject(bindata.ToString());*/
        player = GameObject.Find("Albert2").GetComponent<Player>();
        ala = GameObject.Find("Albert2").GetComponent<Ala>();
        inputHandler = transform.root.GetComponent<Input_Handler>(); 
	}
	
	public void OnTriggerEnter(Collider other) {
       

        if (other.tag == "Boss") {
            if (Ala.swordenter == true)
            {
				//Animator M_ami = other.GetComponent<Animator>();  //暫時用
				//M_ami.SetTrigger("Injured");//暫時被打動畫
                Boss.BasicBoss unit = other.GetComponent<Boss.BasicBoss>();
                JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
                
                jsonObject.AddField("demage", (int)(player.AtkRise*player.AtkRatio*player.ES_AtkRatio));
                //string
                jsonObject.AddField("type", "melee");
                //array
               // unit.m_Ani.SetTrigger("Hit");
				//other.gameObject.AddComponent<Bake>();
                JSONObject arr = new JSONObject(JSONObject.Type.ARRAY);
                jsonObject.AddField("effectList", arr);
                
                if (other.GetComponent<Boss.BasicBoss>())
                {
                    unit.beDamaged(jsonObject);
                }
                else
                {
                    other.GetComponent<Boss.SiteDamage>().beDamaged(jsonObject);
                }
                AttackEffect(other.transform);
                //other.gameObject.AddComponent<Bake>();
            }
        }
	}

	/*void OnTriggerExit(Collider other) {
		if (other.tag == "Boss") {
		//	inputHandler.anim.speed= 1f;
			Ala.swordenter = false;
		}
	}*/

    void AttackEffect(Transform Monster) {
        Vector3 Rot = new Vector3(Monster.transform.rotation.x, Monster.transform.eulerAngles.y, Monster.transform.rotation.z);
        Vector3 Pos = new Vector3(Monster.transform.position.x, Monster.transform.position.y+1, Monster.transform.position.z); 

        //GameObject SM = Instantiate(ala.swardeffect[Ala.attacklevel], Ala.heresST[Ala.attacklevel].transform.position, Ala.heresST[Ala.attacklevel].transform.rotation) as GameObject;
        
        GameObject SM2 = Instantiate(ala.swardeffect[Ala.attacklevel], Pos, Ala.heresST[Ala.attacklevel].transform.rotation) as GameObject;
        print(Ala.heresST[Ala.attacklevel]);
		//GameObject.Find("PlayerCamera").GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>().enabled = true; 
		//GameObject.Find("PlayerCamera").GetComponent<UnityStandardAssets.ImageEffects.BloomAndFlares>().enabled = true;
		Time.timeScale = 0.6F;    //  速度变为原来的0.7倍；
		Time.fixedDeltaTime = 0.02F*Time.timeScale;
		//GameObject.Find("PlayerCamera").GetComponent<Animator>().SetTrigger("Cameraop");
		iTween.PunchPosition(GameObject.Find("PlayerCamera"), aa, Punchtime);
    }


	void Gunmodle()
	{
		if (PlayerMove.SightSwitch == true)
		{
			
			gameObject.GetComponent<BoxCollider>().enabled = false;
			
		}
		else
		{
			gameObject.GetComponent<BoxCollider>().enabled = true;
		}
	}



}
