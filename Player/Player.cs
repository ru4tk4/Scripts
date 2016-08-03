using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    static public int monternum;
    static public int UInum;
    public float AniSpeed =1;

    [System.Serializable]
    public class BGM
    {
        [FMODUnity.EventRef]
        public string inputSound = "";
        FMOD.Studio.EventInstance EI;
        public FMOD.Studio.ParameterInstance enemy;
        public FMOD.Studio.ParameterInstance menu;
        public FMOD.Studio.ParameterInstance upgrade;
        public FMOD.Studio.ParameterInstance die;

        public void st()
        {
            EI = FMODUnity.RuntimeManager.CreateInstance(inputSound);
            EI.getParameter("enemy", out enemy);
            EI.getParameter("menu", out menu);
            EI.getParameter("upgrade", out upgrade);
            EI.getParameter("die", out die);
            EI.start();
            enemy.setValue(0f);
            menu.setValue(0f);
            upgrade.setValue(0f);
            die.setValue(0f);
            
        }

        public void stop()
        {
            EI = FMODUnity.RuntimeManager.CreateInstance(inputSound);
            EI.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        public void play()
        {
            EI = FMODUnity.RuntimeManager.CreateInstance(inputSound);
            EI.start();
        }
    }
    public  void Stop()
    {
        bgm.stop();
    }
    public void Play()
    {
        bgm.play();
    }
    public BGM bgm;
    public enum State {Idle, Attack, Disable, Dead,Aim};
	private Input_Handler inputHandler;
    public Transform LockTraget;
    private GunFire GunFire;
    public WeaponData[] WD;
    public int WD_number;
	public float maxHP = 1000;
    public float HPs = 0.5f;
	public Image DarkPanel;
    public GameObject DarkP;
    public Image DieText;
    public Image HP1;
    public Image HP2;
    public GameObject[] EnergyUI;
	bool XF;
    
	public GameObject cameraeye;
	public GameObject playereye;
	public float cameraSmooth;
	public RuntimeAnimatorController AlcedAC;
	public RuntimeAnimatorController AlaAC;
    public RuntimeAnimatorController NOAC;
    public GameObject BigSwordObj;
	public GameObject AlaObj;
	public GameObject BigSwordWeapon;
	public GameObject AlaWeapon;
    public Animator Hurt;
    public float hp = 100; //生命值
    public float energy = 300f; //能量
    public float Gunlost;//子彈消耗
    public float bulletdem = 5; //子彈威力
    public float bulletRato = 1f;
    public float ES_bulletRato = 1f;
    public float ShootRange = 10; //射程
    public float BulletSpeed = 100; //彈速
    public float fire_CD = 1; //射擊間隔
    public float Magazine = 10; //彈夾量
    public float reloadTime = 2; //裝填時間
    public float AtkRise = 0f; //攻擊上升量
    public float AtkRatio = 1f;
    public float ES_AtkRatio = 1f;

    public float Defense = 0f; //防禦力
    public float HurtRatio = 1f; //傷害比例

    static public int SolidStatu = 0;//無敵狀態
    public float SolidTime;//無敵時間
    float PosY ;

    public bool EN = true;
    static public bool Alce = false;
    static public bool UseAla = true;
    static public bool UseAlce = false;
    public bool Alce_on_off = false;
    public GameObject Alce_icon;
    PlayerSave ps;
    float E;

    public GameObject[] ChangeUI;
    public GameObject[] ManIcon;
    public Animator ChangeWeaponUI;

    public float smoothTime = 0.3F;
    private float yVelocity = 0.0F;
    //public GameObject NewerUI;

    [System.Serializable]
    public class WeaponData
    {
        public string name;
        public float Gunlost;//子彈消耗
        public float bulletdem = 5; //子彈威力
        public float bulletRato = 1f;
        public float ShootRange = 10; //射程
        public float BulletSpeed = 100; //彈速
        public float fire_CD = 1; //射擊間隔
        public float Magazine = 10; //彈夾量
        public float reloadTime = 2; //裝填時間
        public float AtkRise = 0f; //攻擊上升量
        public float AtkRatio = 1f;
        public float Stable;
        public GameObject Bullet; // 子彈特效
        public GameObject Bullet_fire; //槍管特效
        public GameObject Reload_effect; //填充特效
        public GameObject Reload_here; //填充特效位置
        public GameObject Fire_here; //槍口
        public GameObject FireUI;
        public Animator RealoadUI;
        public GameObject MazUI;
        
        public int Magazine_Save; //紀錄子彈
    }

    public void ChangeWeapon(int num)
    {
        WD[WD_number].Magazine_Save = GunFire.Magazine;
        WD_number = num;
        Gunlost = WD[num].Gunlost;
        bulletdem = WD[num].bulletdem;
        //bulletRato = WD[num].bulletRato;
        ShootRange = WD[num].ShootRange;
        BulletSpeed = WD[num].BulletSpeed;
        fire_CD = WD[num].fire_CD;
        Magazine = WD[num].Magazine;
        reloadTime = WD[num].reloadTime;
        AtkRise = WD[num].AtkRise;
        AtkRatio = WD[num].AtkRatio;
        GunFire.bulles = WD[num].Bullet;
        GunFire.bullesFire = WD[num].Bullet_fire;
        GunFire.ReLoad = WD[num].Reload_effect;
        GunFire.Reloadhere = WD[num].Reload_here;
        GunFire.firehere = WD[num].Fire_here;
        GunFire.FireUI00.SetActive(false);
        GunFire.FireUI00 = WD[num].FireUI;
        GunFire.MazUI[WD_number].SetActive(false);
        GunFire.MazUI[num] = WD[num].MazUI;
        GunFire.ReloadUI = WD[num].RealoadUI;
        GunFire.IK_Hand.transform.position = GunFire.firehere.transform.position;
        GunFire.IK_Hand.transform.rotation = GunFire.firehere.transform.rotation;
        GunFire.Magazine = WD[num].Magazine_Save;
        GunFire.stable = WD[num].Stable;
    }


    RuntimeAnimatorController anic;


    /*private void Awake()
    {
       // Application.targetFrameRate = 40;
    }
    */
    void Start()
    {
        bgm.st();
        SolidStatu = 0;//無敵狀態

        InvokeRepeating("resumeArmor", 2, 2f);
		inputHandler = gameObject.GetComponent<Input_Handler>();
        PosY = playereye.transform.localPosition.y;
        GunFire = gameObject.GetComponent<GunFire>();
        ChangeWeapon(0);
        GunFire.IK_Hand.transform.position = WD[WD_number].Fire_here.transform.position;
        GunFire.IK_Hand.transform.rotation = WD[WD_number].Fire_here.transform.rotation;
        ps = GetComponent<PlayerSave>();
        E = energy;
        anic = inputHandler.anim.runtimeAnimatorController;
    }
	private float darkness = 0;

    void FixedUpdate() {
        if (PlayerMove.SightSwitch == false)
        {
            float EyePos = inputHandler.anim.GetFloat("EyePos");
            
            playereye.transform.localPosition = new Vector3(playereye.transform.localPosition.x, PosY * EyePos, playereye.transform.localPosition.z);
            cameraeye.transform.position = Vector3.Lerp(cameraeye.transform.position, playereye.transform.position, cameraSmooth * Time.deltaTime);

        }


    }


    private float darkness1 = 0;
    void music()
    {
        if (monternum <= 2)
        {
            bgm.enemy.setValue(monternum);
        }
        else
        {
            bgm.enemy.setValue(2);
        }
        if (UInum == 1)
        {
            bgm.menu.setValue(1);
            bgm.upgrade.setValue(0);
        }
        else if (UInum == 2)
        {
            bgm.upgrade.setValue(1);
            bgm.menu.setValue(0);
        }
        else
        {
            bgm.menu.setValue(0);
            bgm.upgrade.setValue(0);
        }
        AudioSource soundSource = gameObject.GetComponent<AudioSource>();
    }

    void EnergySystem()
    {
        inputHandler.anim.SetFloat("Runspeed", AniSpeed);       
    }

    void PlayerUI()
    {
        if (energy > E)
        {
            LLLLLL.E += (energy - E);

        }
        E = energy;
       // HP1.fillAmount = hp / 100;
        //HP2.fillAmount = hp / 100;
    }
    void gameover()
    {
        inputHandler.currentState = State.Dead;
        inputHandler.anim.SetTrigger("Dead");
        inputHandler.anim.SetBool("Deading", true);
        Cursor.visible = false;
        bgm.die.setValue(1);
        foreach (GameObject A in EnergyUI)
        {
            A.SetActive(false);
        }
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.GetComponent<PlayerMove>().enabled = false;
        darkness1 += 1f * Time.deltaTime;
        DieText.color = new Vector4(255, 255, 255, Mathf.Clamp(darkness1, 0, 1));

        DarkP.SetActive(true);
        darkness += 0.8f * Time.deltaTime;
        DarkPanel.color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
        if (darkness >= 0.95f && darkness < 1f)
        {
          
            darkness = 1f;
            string J = SceneManager.GetActiveScene().name;
            ps.die(J);

        }
    }


    /*if (energy < 100)
    {
        energy = Mathf.SmoothDamp(energy, 100f, ref yVelocity, smoothTime);
    }*/
    void Update(){
  
        PlayerUI();
       // music();
        EnergySystem();
        Weaponchange ();


        if (hp<=0)
        {
            gameover();
        }
       

     /*   if (energy <= 0)
        {
            energy = 0;
            foreach (GameObject B in ManIcon)
            {
                B.SetActive(true);
            }
            foreach (GameObject A in ChangeUI)
            {
                A.GetComponent<Animator>().SetBool("Open", true);
            }
            Hurt.SetBool("Keep", true);
            EN = false;
        }


        if (energy > 0)
        {
            foreach (GameObject B in ManIcon)
            {
                B.SetActive(false);
            }
            foreach (GameObject A in ChangeUI)
            {
                A.GetComponent<Animator>().SetBool("Open", false);
            }
            Hurt.SetBool("Keep", false);
            EN = true;
        }*/

        /*if (hp < 100)
     {
         hp = Mathf.SmoothDamp(hp, 100f, ref yVelocity, 15);
     }

     if (hp < 60)
     {
         HP1.GetComponent<Image>().color = new Color(1, 0.8f, 0.58f, 1);
         HP2.GetComponent<Image>().color = new Color(1, 0.8f, 0.58f, 1);
     }
     if (hp < 30)
     {
         HP1.GetComponent<Image>().color = new Color(1, 0.2f, 0.2f, 1);
         HP2.GetComponent<Image>().color = new Color(1, 0.2f, 0.2f, 1);
     }
     if (hp > 60)
     {
         HP1.GetComponent<Image>().color = new Color(0.64f, 1, 0.58f, 1);
         HP2.GetComponent<Image>().color = new Color(0.64f, 1, 0.58f , 1);
     }*/

    }


	/*public void underAttack(float damage) {
		if (energy > 0) {
            if((damage*HurtRatio)-Defense > 0) {
                energy -= (damage * HurtRatio) - Defense;
            }
			
		} else {
            if ((damage * HurtRatio) - Defense > 0)
            {
                hp -= (damage * HurtRatio) - Defense;
            }
        }
	}*/


	//Update Version
	public void underBossAttack(JSONObject attackData,bool Gun) {
		if (inputHandler.currentState != State.Dead && SolidStatu == 0) {
			float damage = attackData.GetField("damage").n;
			string effect = attackData.GetField("effect").str;
          /*  if (Gun == false )
            {
                gameObject.GetComponent<EffectOpen>().EffectOpenEvent(3);
            }           		*/
			hp -= (damage * HurtRatio) - Defense;            
			effectAttacher(effect);			
		}
	}

    public void underAttack(float damage, string effect)
    {    
        if (inputHandler.currentState != State.Dead && SolidStatu == 0)
        {
            hp -= (damage * HurtRatio) - Defense;
            effectAttacher(effect);            
            //StartCoroutine(SolidStatuTime(SolidTime));
        }
    }
/*
    IEnumerator SolidStatuTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

       // SolidStatu = 0;
        
    }*/

    

    private void effectAttacher(string effect)
    {

        if (inputHandler.currentState != Player.State.Disable)
        {

            switch (effect)
            {

                case "fly":

                    flyEffect();

                    break;

                case "under":

                    underEffect();

                    break;

                case "push":

                    pushEffect();

                    break;

                case "rf":

                    RfEffect();

                    break;
                default:

                    break;

            }

        }

    }



    public void energyalter(float amount)
    {

        energy += amount;

    }



    public void Resume()
    {

        inputHandler.currentState = Player.State.Idle;

    }



    private void flyEffect()
    {

        SolidStatu = 1;

        GunFire.LockWaitVoid(5f);

        inputHandler.anim.SetTrigger("Fly");

        inputHandler.currentState = Player.State.Disable;

    }



    private void underEffect()

    {

        SolidStatu = 1;

        GunFire.LockWaitVoid(3f);

        inputHandler.anim.SetTrigger("Under");

        inputHandler.currentState = Player.State.Disable;

    }
    public GameObject Leffff;
    private void RfEffect()

    {

        SolidStatu = 1;

        GunFire.LockWaitVoid(3f);

        inputHandler.anim.SetTrigger("Rf");
        Leffff.SetActive(true);
        Invoke("A", 1.5f);
        inputHandler.currentState = Player.State.Disable;

    }

    public void A()
    {
        Leffff.SetActive(false);
    }

    private void pushEffect() {
        AnimatorStateInfo currentState = inputHandler.anim.GetCurrentAnimatorStateInfo(0);
        if (currentState.fullPathHash != Animator.StringToHash("Base Layer.Attack1"))
        {
            GunFire.LockWaitVoid(1f);
            inputHandler.anim.SetTrigger("Hurt");
            inputHandler.currentState = Player.State.Disable;
        }
	}

	void Deading(){


		gameObject.GetComponent<Input_Handler> ().enabled = false;

	}
    float TIMEH = 1;
    float TT ;
    bool nono = false;
    
    public void Weaponchange()
    {

        if (Alce == true && Input.GetAxis("Weapon2")>0.5&&TT<Time.time)
        {
            TT = Time.time + TIMEH;
            UseAla = false;
            UseAlce = true;
            GunFire.LockWaitVoid(1f);
            inputHandler.anim.runtimeAnimatorController = AlcedAC;
            ChangeWeaponUI.SetTrigger("Alce");
            inputHandler.anim.SetTrigger("Weaponchange");
            BigSwordWeapon.SetActive(true);
            AlaWeapon.SetActive(false);         
            ChangeWeapon(1);
            GunFire.WpchangeReload();
        }
        Debug.Log(Input.GetAxis("Weapon1"));
        
		if (Input.GetAxis("Weapon1") > 0.5 && TT < Time.time)
        {

            TT = Time.time + TIMEH;
            UseAla = true;
            UseAlce = false;
            GunFire.LockWaitVoid(1f);
            inputHandler.anim.runtimeAnimatorController = AlaAC;
            ChangeWeaponUI.SetTrigger("Ala");
            inputHandler.anim.SetTrigger("Weaponchange");
			AlaWeapon.SetActive(true);
			BigSwordWeapon.SetActive(false);
            ChangeWeapon(0);
            GunFire.WpchangeReload();
        }


        if (Input.GetButton("Fire3"))
        {

            AlaWeapon.SetActive(false);
            BigSwordWeapon.SetActive(false);

        }
        else
        {
            switch (WD_number)
            {
                case 0:

                    AlaWeapon.SetActive(true);

                    break;

                case 1:

                    BigSwordWeapon.SetActive(true);

                    break;

                default:
                    AlaWeapon.SetActive(true);
                    break;

            }

        }

        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (nono == false)
            {
                nono = true;
                anic = inputHandler.anim.runtimeAnimatorController;
                inputHandler.anim.runtimeAnimatorController = NOAC;
                inputHandler.anim.SetTrigger("Weaponchange");
                AlaWeapon.SetActive(false);
                BigSwordWeapon.SetActive(false);
                GunFire.lockWait = true;
            }
            else
            {
                nono = false;
                    inputHandler.anim.runtimeAnimatorController = anic;
                    inputHandler.anim.SetTrigger("Weaponchange");
                    GunFire.lockWait = false;
                    switch (WD_number)
                    {
                        case 0:

                            AlaWeapon.SetActive(true);

                            break;

                        case 1:

                            BigSwordWeapon.SetActive(true);

                            break;

                        default:
                            AlaWeapon.SetActive(true);
                            break;

                    }
                }
                
        }*/
        /*
        if (Input.GetButtonUp("Fire3"))
        {
            inputHandler.anim.runtimeAnimatorController = anic;
            inputHandler.anim.SetTrigger("Weaponchange");
            GunFire.lockWait = false;
            switch (WD_number)
            {
                case 0:

                    AlaWeapon.SetActive(true);

                    break;

                case 1:

                    BigSwordWeapon.SetActive(true);

                    break;

                default:
                    AlaWeapon.SetActive(true);
                    break;

            }
        }
        */
    }

    public void HurtUI()
    {
        Hurt.SetTrigger("Open");
    }
}
