using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Boss {
	public class BasicBoss : MoveClass {
		public enum BossState {Idle, Move, Stun, Block, Attack, Dead};
		public BossState state = BossState.Idle;
		public float hp = 500;
		public SkillState currentState;
		public int maxWalkVelocity = 1;
		public int maxAttackVelocity = 2;
		public float attackRange = 2;
		public float spawnRange = 15;
		public int searchRadius = 15;
		public int loseVisionRange = 30;
		public int playerLayer = 1 << 10;
		public int terrainLayer = 1 << 8;
		public Transform target;
		public Transform basePos;
		public Vector3 centerPoint;
		public bool isRange = false;
        public float RangeTimeMin = 2f;
        public float RangeTimeMax = 2f;
        public List<AttackSet> attackSets = new List<AttackSet>();
		public JSONObject bossData;
       
        public BossAttackCollider[] bossAttackColliders;
        public float turndelay = 2;//轉向時間
        public bool stunOpen = false; //是否啟動暈眩
        public bool Battle = false;//是否戰鬥狀態
        public bool BigBattle = false; 
        public bool stiff = false; //是否使用僵直
        public int stiffV = 3;//僵直次數
        int stiffVO = 0;
        public float PowerfulTime = 3;//無僵直時間



        public Transform B_FireObj;//槍口位置
        public GameObject B_bullet;//子彈
        public GameObject B_bulletFire;//
        public float B_bulletSpeed;//子彈數度
        public bool IFIK;//射擊動作IK
        public Transform IK_AimTarget;//IK瞄準點
        public float IK_LestTime;//IK啟動延遲時間

        
        public float LockUp = 1.2f; //鎖定怪物位置

        public Bosspatrol selfpatrol;
        public BossDie selfDie;
        public BossDistance selfDistance;
        public MonterRender selfRender;
        protected DemageBehavior damagebehavior;
        public NavMeshAgent NMA;
        public Vector3 stpos;
        public float attCD = 0;
        public float atttime = 0;
        public void Start() {
            if (GetComponent<NavMeshAgent>())
            {
                NMA = GetComponent<NavMeshAgent>();
            }
            bossAttackColliders = GetComponentsInChildren<BossAttackCollider>();
			centerPoint = transform.position;
            stiffVO = stiffV;
            damagebehavior = new DemageBehavior(this);
            stpos = transform.position;
        }

        public void Update()
        {
         /*   if (NewerUI.Gamepaused == true)
            {
                m_Ani.speed = 0f;

            }
            else
            {
                m_Ani.speed = 1f;
               
                
            }*/
            currentState.execute();
        }


        public void FixedUpdate () {

            
            calculateGrivaty();
		}
		
		public void changeState(SkillState newState) {
			currentState.exit();
			currentState = newState;
			newState.enter(this);
		}
       
        public virtual void beDamaged(JSONObject json) {
				damagebehavior.demaged(json);
			
		}

		public void getBossData(string bossName) {
			TextAsset bindata= Resources.Load("Boss/BossData") as TextAsset;
			JSONObject jsonObject = new JSONObject(bindata.ToString());
			bossData = jsonObject.GetField(bossName);
		}


        public void stiffReturn()
        {
            StartCoroutine(stiffTime(PowerfulTime));
        }

        IEnumerator stiffTime(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            stiffV += stiffVO;

        }

        public void DelayAttack(float Delaytime)
        {
            Invoke("Attack", Delaytime);
        }

        public void Attack()
        {
            GetComponent<AttackSkill>().Fire();
        }

        public void IKSwitch(bool Onoff)
        {
            gameObject.GetComponent<RootMotion.FinalIK.Demos.CharacterControllerSimpleAim>().enabled = Onoff;
            gameObject.GetComponent<RootMotion.FinalIK.Demos.SimpleAimingSystem>().enabled = Onoff;          
        }

        
       
       //目標資料
        public Vector4 TargetData()
        {
            float AngleF = 0;
            float AngleR = 0;
            float AngleU = 0;
            float distance = 0;
            Vector3 playerhere;
            Vector4 targetDate;
            distance = Vector3.Distance(target.position, transform.position);
           
            playerhere = target.position - transform.position;

            AngleF = Vector3.Angle(transform.forward, playerhere);
            AngleR = Vector3.Angle(transform.right, playerhere);
            AngleU = Vector3.Angle(transform.up, playerhere);
            targetDate = new Vector4(AngleF, AngleR, AngleU, distance);
            return targetDate;
        }
        public void monterGO()
        {
            if (state == BasicBoss.BossState.Idle)
            {
               // target = GameObject.FindGameObjectWithTag("Player").transform;
                changeState(gameObject.AddComponent<TraceSkill>());
            }
        }

     

        [System.Serializable]
        public class BossDistance
        {
            public float look = 10 ;//視線距離
            public float BattleDistance = 10;//戰鬥狀態距離
            public Vector2 RangeDistance = new Vector2(7,20);//遠距攻擊距離
            public float AttackDistance = 4;//普通攻擊距離
            public float TraceDistance = 12;//追逐最短距離
            public float TraceMax = 25;//追逐最遠距離

        }
        [System.Serializable]
        public class BossDie
        {

            public GameObject energy;//掉落能量
            public GameObject energytarget;//掉落位置
            public int energyV;//能量數量
            public GameObject DeadEffect;//死亡特效
            public GameObject DeadUI;//死亡移除地圖紅點
            public GameObject[] DeadInstantiate;//物件
            public GameObject[] DeadDestroy;//移除物件
            public GameObject[] DeadSetActice; //死亡顯現物品

        }
        [System.Serializable]
        public class Bosspatrol

        {

            public bool pathOnOff;//是否啟用區域巡邏
            public Path1 path;//巡邏區域
            public float speed = 0.1f;//巡邏速度
            public float mass = 5f;//
            public bool isLooping = true;
            
        }

        [System.Serializable]
        public class MonterRender

        {
            public SkinnedMeshRenderer monder;
            

        }
        int K = 0;
        
        public void renderbake()
        {
            K++;
            StartCoroutine(RenderTime(0.05f,K));
        }
        IEnumerator RenderTime(float waitTime ,int i)
        {
            yield return new WaitForSeconds(waitTime);

            //selfRender.monder.material.SetFloat("_Outline", 0f);
            if (i==K)
            {
                if(selfRender.monder)
                    selfRender.monder.material.SetColor("_TintColor",Color.black );
                //selfRender.monder.material.SetFloat("_Outline", 0f);
                K = 0;                
            }
        }

    }
}
