using UnityEngine;
using System.Collections;

public class PlayerMove : MoveClass 
{
    public string tagg;
	public Transform m_CameraDir;	//攝影機角度
	private Input_Handler inputHandler;
    static public bool RotaNo = false;

    static public bool SightSwitch = false ;
    public float j_DonHi=1f;
	float Roll_CD_Time;
	public float Roll_CD = 0.2f ;
    int Jamp = 1;
    float JampSpeed = 1;
    float DS = 0;

    float MX;
    float MY;
    public float DirectionDampTime = .25f;
    public float RunDampTime = .25f;
    float runY = 2;
    public GameObject sword;
    void Start () 
	{
        Cursor.lockState = CursorLockMode.Locked;
        
        if (!m_CharCtrl) this.enabled = false;
		if (!m_Ani) this.enabled = false;
		inputHandler = gameObject.GetComponent<Input_Handler>();
		Roll_CD_Time = Time.time + 1;
	}
	void LateUpdate() 
	{
        
        if (m_CanCtrl && inputHandler.currentState != Player.State.Dead)
		{
           
           
			CharacterAni();           
            Ray();
           
            if (RotaNo == false)
            {
                
            }

            if (SightSwitch == false) {
                CharacterMove();
                MX = 0;
                MY = 2;
                CharacterRotation();
                m_Ani.SetFloat("RunX",0, RunDampTime, Time.deltaTime);
                m_Ani.SetFloat("RunY", runY, RunDampTime, Time.deltaTime);
                m_Ani.SetFloat("Idletree", 0,0.1f, Time.deltaTime);
                //m_Ani.SetFloat("RunDirection1", 5);
                RotaNo = false;
            }
            else
            {
                //m_Ani.SetBool("Run", false);
                m_Ani.SetFloat("Idletree", 1, 0.1f, Time.deltaTime);
                RotaNo = true;
                gunmove();
                MoveDir.x = 0;
                MoveDir.z = 0;
            }

        }
        //所有計算完成,應用移動數據
        
        m_CharCtrl.Move (MoveDir * Time.deltaTime);
	}

	//物理Updae
	void FixedUpdate()
	{
		if (m_UseGrivate)
		{
			Grivate();
		}
	}

    //離地距離
    void Ray()
    {
        RaycastHit hit;
        Vector3 Linmon = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+1, gameObject.transform.position.z);
        if (Physics.Raycast(Linmon, -gameObject.transform.up, out hit, 500f,1023))
        {
            
            DS = Vector3.Distance(gameObject.transform.position, hit.point);
            tagg = hit.collider.tag;
        }

        if (DS> j_DonHi && JampSpeed > 0.1)
        {
            JampSpeed -= 0.05f;
        }
        if (DS <= j_DonHi && JampSpeed <= 1)
        {
            JampSpeed += 0.05f;
        }
    }



    //重力計算
    public void Grivate()
	{
		if (!m_CharCtrl.isGrounded)
		{
			m_isGround = false;
           // m_Ani.SetBool("Enter", false);
            
            MoveDir.y -= m_Grivate * Time.deltaTime;
		}
		else
		{
			m_isGround = true;
           // m_Ani.SetBool("Enter", true);
           
        }
		//限制最大掉落速度 = 重力*2
		if (MoveDir.y <= -m_Grivate*20 && m_Grivate != 0)
		{
			MoveDir.y = -m_Grivate*20;
		}
	}
    //動畫控制
    bool two =false;

    IEnumerator StatuTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        two = false;
        // SolidStatu = 0;


    }

    string t;
    float rt =0.6f;
    float kt;
    public void CharacterAni()
    {
        AnimatorStateInfo currentState = m_Ani.GetCurrentAnimatorStateInfo(0);
        m_Ani.SetFloat("JampSpeed", JampSpeed);
        if (Input.GetButtonDown("Fire3"))
        {
            kt = Time.time + rt;
        }

        if (Input.GetButton("Fire3") && kt < Time.time)
        {
            
            //sword.SetActive(true);
            runY = 3;
            
        }
        else
        {
           // sword.SetActive(false);
            runY = 2;
            
        }
        if (Input.GetButtonUp("Fire3") && Time.time > Roll_CD_Time && inputHandler.currentState != Player.State.Dead&&kt>Time.time)
        {
            rotaon();
            m_Ani.SetTrigger("Roll");
            CharacterMove();
           
            Roll_CD_Time = Time.time + Roll_CD;
        }
        else { 
}
        if (inputHandler.Attack_Num < 1 && inputHandler.currentState != Player.State.Dead)
        {


            if (Input.GetAxis("MoveX") > 0.5 || Input.GetAxis("MoveY") > 0.5 || Input.GetAxis("MoveX") < -0.5 || Input.GetAxis("MoveY") < -0.5)
            {
                m_Ani.SetBool("Run", true);

            }
            else
            {
                m_Ani.SetBool("Run", false);
            }

            if ((Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.D)))
            {

                string w = Input.inputString;
                if (two == true && Time.time > Roll_CD_Time && t == w)
                {
                    rotaon();
                    m_Ani.SetTrigger("Roll");
                    CharacterMove();
                    
                    Roll_CD_Time = Time.time + Roll_CD;
                }
                else
                {
                    two = true;
                    t = w;
                    StartCoroutine(StatuTime(0.2f));
                }
            }



            

			if (Input.GetButtonDown("Jump")&&Time.time>Roll_CD_Time&& m_CharCtrl.isGrounded)
			{
				m_Ani.SetTrigger("Jump");
				
				Roll_CD_Time=Time.time+Roll_CD;
                
                MoveDir = transform.forward * m_MoveSpeed + new Vector3(0,m_JumpHeight, 0);
            }


		}
		else
		{           
			m_Ani.SetBool("Run",false);
		}

	}
    //射擊移動
    
    void gunmove()
    {

        MX = Input.GetAxis("MoveX");
        MY = Input.GetAxis("MoveY");

        /*if (PlayerMove.SightSwitch == true)
        {
            m_Ani.SetFloat("RunDirection1", 4, DirectionDampTime, Time.deltaTime);

        }
        if (PlayerMove.SightSwitch == false)
        {
            m_Ani.SetFloat("RunDirection1", 5);

        }*/
        if ((PlayerMove.SightSwitch == true))
        {
            m_Ani.SetFloat("RunX", MX, RunDampTime, Time.deltaTime);
            m_Ani.SetFloat("RunY", MY, RunDampTime, Time.deltaTime);
           /* if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                m_Ani.SetFloat("RunDirection1", 1, RunDampTime, Time.deltaTime);

            }
            else
            {
                m_Ani.SetFloat("RunDirection1", 4, RunDampTime, Time.deltaTime);

            }
          */

        }
       


    }


    //移動計算
    public void CharacterMove()
	{

        //用動畫判斷移動,MoveDir是移動的向量,其Y軸是重力
        AnimatorStateInfo currentState = m_Ani.GetCurrentAnimatorStateInfo(0);

        if (currentState.fullPathHash == Animator.StringToHash("Base Layer.Run") || currentState.fullPathHash == Animator.StringToHash("Base Layer.jump"))
        {

            if (Input.GetAxis("MoveX") > 0.5 || Input.GetAxis("MoveY") > 0.5 || Input.GetAxis("MoveX") < -0.5 || Input.GetAxis("MoveY") < -0.5)
            {                //移動時以角色的正前方 * 移動速度為移動向量

                MoveDir = transform.forward * m_MoveSpeed + new Vector3(0, MoveDir.y, 0);


            }
        }
        else
        {
            MoveDir.x = 0;
            MoveDir.z = 0;
        }
		
		

		
	}
    //旋轉計算
    public void CharacterRotation()
    {

        AnimatorStateInfo currentState = m_Ani.GetCurrentAnimatorStateInfo(0);
        if (currentState.fullPathHash == Animator.StringToHash("Base Layer.Run") || currentState.fullPathHash == Animator.StringToHash("Base Layer.jump")|| currentState.fullPathHash == Animator.StringToHash("Base Layer.Idle"))
        {
            float yVelocity = 0.0F;

            if (Input.GetAxis("MoveX") < -0.5 & Input.GetAxis("MoveY") > 0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 45, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveX") > 0.5 & Input.GetAxis("MoveY") > 0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 45, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveX") < -0.5 & Input.GetAxis("MoveY") < -0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 135, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveX") > 0.5 & Input.GetAxis("MoveY") < -0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 135, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveY") > 0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 0, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveX") < -0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 90, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveY") < -0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 180, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveX") > 0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 90, ref yVelocity, m_RotaSpeed), 0);
            }
        }



    }

    public void rotaon()
    {
        

        if (Input.GetAxis("MoveX") < -0.5 & Input.GetAxis("MoveY") > 0.5)
        {
            transform.eulerAngles = new Vector3(0, m_CameraDir.eulerAngles.y - 45, 0);
        }
        else if (Input.GetAxis("MoveX") > 0.5 & Input.GetAxis("MoveY") > 0.5)
        {
            transform.eulerAngles = new Vector3(0,m_CameraDir.eulerAngles.y + 45, 0);
        }
        else if (Input.GetAxis("MoveX") < -0.5 & Input.GetAxis("MoveY") < -0.5)
        {
            transform.eulerAngles = new Vector3(0, m_CameraDir.eulerAngles.y - 135, 0);
        }
        else if (Input.GetAxis("MoveX") > 0.5 & Input.GetAxis("MoveY") < -0.5)
        {
            transform.eulerAngles = new Vector3(0,  m_CameraDir.eulerAngles.y + 135, 0);
        }
        else if (Input.GetAxis("MoveY") > 0.5)
        {
            transform.eulerAngles = new Vector3(0, m_CameraDir.eulerAngles.y + 0, 0);
        }
        else if (Input.GetAxis("MoveX") < -0.5)
        {
            transform.eulerAngles = new Vector3(0, m_CameraDir.eulerAngles.y - 90, 0);
        }
        else if (Input.GetAxis("MoveY") < -0.5)
        {
            transform.eulerAngles = new Vector3(0, m_CameraDir.eulerAngles.y - 180,  0);
        }
        else if (Input.GetAxis("MoveX") > 0.5)
        {
            transform.eulerAngles = new Vector3(0, m_CameraDir.eulerAngles.y + 90, 0);
        }
    }

    public void Roll()
	{
        AnimatorStateInfo currentState = m_Ani.GetCurrentAnimatorStateInfo(0);
        if (currentState.fullPathHash == Animator.StringToHash("Base Layer.Roll"))
        {
            MoveDir.x = 0;
            MoveDir.z = 0;
        }
		
	} 
}
