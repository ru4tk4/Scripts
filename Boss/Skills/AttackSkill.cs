using UnityEngine;
using System.Collections;

namespace Boss {
	public class AttackSkill : MonoBehaviour, SkillState {
		private BasicBoss self;
		private AttackBehavior attackBehavior;
		private JumpBehavior jumpBehavior;
		private GameObject rock;
        private bool FireSwitch = false;
        Vector2 F;
        Vector3 K;


        #region SkillState implementation

        public void execute () {
            if (FireSwitch) {
                self.IK_AimTarget.transform.parent = null;
                Vector3 playerPOS = new Vector3(GameObject.Find("Albert2").transform.position.x, GameObject.Find("Albert2").transform.position.y + 1.5f, GameObject.Find("Albert2").transform.position.z);
                self.IK_AimTarget.transform.position = Vector3.Lerp(self.IK_AimTarget.transform.position, playerPOS, self.IK_LestTime * Time.deltaTime);
            }
        }

        public void enter(BasicBoss boss)
        {
            self = boss;
            if (self.hp >= 0)
            {
                attackBehavior = new AttackBehavior();
                jumpBehavior = new JumpBehavior(self);

                float distance = Vector3.Distance(self.target.position, self.transform.position);



                if (distance > self.selfDistance.RangeDistance.x)
                {

                    JSONObject RangeAttackObject = attackBehavior.getAttackAnimate(self.bossData.GetField("RangeWeapon").list);
                    Debug.Log(RangeAttackObject.GetField("name").str);
                    foreach (BossAttackCollider weapon in self.bossAttackColliders)
                    {
                        weapon.attackInfo = RangeAttackObject;
                    }
                    self.m_Ani.SetTrigger("Range");
                    self.m_Ani.SetTrigger(RangeAttackObject.GetField("name").str);

                    return;
                }

                JSONObject attackObject = attackBehavior.getAttackAnimate(self.bossData.GetField("AttackList").list);
                foreach (BossAttackCollider weapon in self.bossAttackColliders)
                {
                    weapon.attackInfo = attackObject;
                }



                self.m_Ani.SetTrigger("Attack");
                self.m_Ani.SetTrigger(attackObject.GetField("name").str);
            }
        }
		
		public void exit ()	{
			Destroy(this);
		}
		
		
		#endregion
		private void attackState(bool switchOn) {
			foreach(BossAttackCollider weapon in self.bossAttackColliders) {
				weapon.on = switchOn;
			}
		}
		
		public void Fire() {
			self.state = BasicBoss.BossState.Attack;
			attackState(true);
            float Rota = self.transform.eulerAngles.y;
            Transform TAG = self.transform;
            TAG.LookAt(GameObject.Find("Albert2").transform);
            self.transform.rotation = Quaternion.Euler(self.transform.rotation.x, TAG.transform.eulerAngles.y, self.transform.rotation.z);
            if (Mathf.Abs(Rota - TAG.transform.eulerAngles.y) > 120) { 
            self.transform.rotation = Quaternion.Euler(self.transform.rotation.x, Rota, self.transform.rotation.z);
               // print("A" + Rota + "    B" + TAG.transform.eulerAngles.y);
            }
        }

        public void FireGun()
        {
            //Vector3 playerPOS = new Vector3(GameObject.Find("Albert2").transform.position.x, GameObject.Find("Albert2").transform.position.y+2, GameObject.Find("Albert2").transform.position.z) ;
            //self.B_FireObj.transform.LookAt(playerPOS);
            /*self.B_bullet.transform.position = self.B_FireObj.transform.position;
            self.B_bullet.active =true;*/
            //self.B_FireObj.LookAt(self.IK_AimTarget.position);
            JSONObject attackObject = attackBehavior.getAttackAnimate(self.bossData.GetField("AttackList").list);
            GameObject bulle = Instantiate(self.B_bullet, self.B_FireObj.transform.position, self.B_FireObj.transform.rotation) as GameObject;
            GameObject bulle1 = Instantiate(self.B_bulletFire, self.B_FireObj.transform.position, self.B_FireObj.transform.rotation) as GameObject;
            bulle.GetComponent<Rigidbody>().AddForce((self.B_FireObj.transform.forward + new Vector3(0, 0, 0)) * self.B_bulletSpeed);
            
           
        }

        public void MagicFire()
        {
            int R = Random.Range(0, 9);
            float Pie = 20;
            int V = 20;
            if(R > 5)
            {
                K = gameObject.transform.position;
                Pie =  20;
                V = 20;

            }
            else
            {
                K = self.target.position;
                Pie = 4;
                V = 5;
            }
            
            for (int i = 0; i < V;)
            {
                F = Random.insideUnitCircle * Pie;
                Vector3 V3 = new Vector3(K.x + F.x, gameObject.transform.position.y, K.z + F.y);
                if (Vector3.Distance(V3, self.target.transform.position) > 3)
                {
                    GameObject Magic = Instantiate(self.B_bullet, V3, gameObject.transform.rotation) as GameObject;
                    i++;
                }
                
                
            }
           
            
        }

        public void LighteningFire()
        {
            
            float Pie = 20;
            int V = 20;


            K = gameObject.transform.position;
            Pie = 20;
            V = 20;

      

            for (int i = 0; i < V;)
            {
                F = Random.insideUnitCircle * Pie;
                Vector3 V3 = new Vector3(K.x + F.x, gameObject.transform.position.y, K.z + F.y);

                GameObject Magic = Instantiate(self.B_bullet, V3, gameObject.transform.rotation) as GameObject;
                i++;
                

            }


        }

        public void HandAttack()
        {

            GameObject Magic = Instantiate(self.B_bullet, self.target.position, gameObject.transform.rotation) as GameObject;


        }

        public void GunAim()
        {
            
            self.IKSwitch(true);
            FireSwitch = true;
            
        }


        public void Range()
        {
            JSONObject weaponInfo = self.bossData.GetField("JumpWeapon");
            
            GameObject rangeWeapon = Resources.Load("Boss/" + weaponInfo.GetField("name").str) as GameObject;
            rock = Instantiate(rangeWeapon, self.target.position, rangeWeapon.transform.rotation) as GameObject;
            /*foreach (BossAttackCollider weapon in self.bossAttackColliders)
            {
                weapon.attackInfo = weaponInfo;
            }*/

            //attackState(true);
        }

        public void Jump() {
			self.state = BasicBoss.BossState.Attack;
			self.transform.LookAt(rock.transform);
			attackState(true);

			self.m_Ani.SetBool("Jump", true);
			
			jumpBehavior.jumpToPosition(rock.transform);
		}
		
		
		public void Land() {
			jumpBehavior.jumpImpactCheck(self.bossData.GetField("RangeWeapon"));
			self.m_Ani.SetBool("Jump", false);
		}
		
		public void Hold() {
            if (self.IFIK == true)
            {
                self.IKSwitch(false);
            }
            self.changeState(gameObject.AddComponent<TraceSkill>());
			attackState(false);
		}
       

		public void OnHold(){
			attackState(false);
		}

	}
}