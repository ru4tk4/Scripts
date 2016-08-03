using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Boss {
	public class DemageBehavior {
		BasicBoss self;
		int undertakeDamage = 0;
		int maxStun = 2;
		int currentStun = 0;
		float fullHP;

		float periodhPLineToCheckPerNum;
		float periodhPLineToCheck;

		public DemageBehavior(BasicBoss boss) {
			self = boss;
			fullHP = self.hp;
			periodhPLineToCheckPerNum = fullHP / 5;
			periodhPLineToCheck = fullHP - periodhPLineToCheckPerNum;
		}

        

        public void demaged(JSONObject info) {
			if (self.state != BasicBoss.BossState.Dead) {
				string demageType = info.GetField("type").str;
				int demage = (int)info.GetField("demage").n;
				self.hp -= demage;
                //self.selfRender.monder.material.SetFloat("_Outline", 0.003f);
                if(self.selfRender.monder)
                    self.selfRender.monder.material.SetColor("_TintColor", new Color(1, 1, 1, 1));

                self.renderbake();
                if (self.stiff == true&&self.hp>0&&self.stiffV>0&& self.state != BasicBoss.BossState.Attack)
                {
                    
                    //self.changeState(self.gameObject.AddComponent<StiffSkill>());
                    self.m_Ani.SetTrigger("Stiff");
                    //
                    if (Vector3.Distance(self.target.position, self.transform.position) < 4)
                    {
                        self.m_Ani.SetTrigger("AAA");
                    }
                    self.stiffV -= 1;
                    

                }
                else if (self.stiffV <= 0)
                {
                    self.stiffReturn();
                }

                self.m_Ani.SetInteger("HP",(int)((self.hp/fullHP)*10));

                if (self.hp <= 0 ) {
					//DIE
					self.changeState(self.gameObject.AddComponent<DeadSkill>());
                    if (self.selfRender.monder)
                        self.selfRender.monder.material.SetColor("_TintColor", Color.black);
                }
	
				if (self.hp < periodhPLineToCheck) {
					stunHandler();
				}
				
				List<JSONObject> effectList = info.GetField("effectList").list;
				
				if (self.state == BasicBoss.BossState.Idle) {
					//self.target = GameObject.FindGameObjectWithTag("Player").transform;
					self.changeState(self.gameObject.AddComponent<TraceSkill>());
				}
				
			}
		}

		public void stunHandler() {
			periodhPLineToCheck =  periodhPLineToCheck - periodhPLineToCheckPerNum;
			float remain = self.hp / fullHP;
			float stunChance = (1 - remain);
			float possibleStunChance = (float) Random.Range(0, 100) / 100;
			if (stunChance > possibleStunChance && currentStun < maxStun && self.state != BasicBoss.BossState.Stun && self.state != BasicBoss.BossState.Block && self.stunOpen == true) {
				currentStun++; 
				self.m_Ani.SetTrigger("Stun");
				self.state = BasicBoss.BossState.Stun;
				//self.changeState(self.gameObject.AddComponent<StunSkill>());

			}
		}

		public void golemEffect(float n, int endureN) {
			undertakeDamage += (int)n;
			if (undertakeDamage >= endureN && self.state != BasicBoss.BossState.Block && self.state != BasicBoss.BossState.Stun&&self.stunOpen==true) {
				undertakeDamage = 0;
               
				self.m_Ani.SetBool("Block", true);
				//self.changeState(self.gameObject.AddComponent<StunSkill>());
			}
		}

		public void effectHandler(List<JSONObject> effects) {

			foreach(JSONObject effect in effects) {
				effectAttacher(effect);
			}
		}

		public void effectAttacher(JSONObject json) {
			switch (json.GetField("name").str) {
				case "freeze" :
				break;
				case "burn" :
				break;
				case "poison" :
				break;
				case "stun" :
				break;
				case "push" :
				break;
				default :
				break;
			}
		}

	}
}