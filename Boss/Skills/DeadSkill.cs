using UnityEngine;
using System.Collections;

namespace Boss {
	public class DeadSkill : MonoBehaviour, SkillState {
		private BasicBoss self;
        private MonoBehaviour[] K;
		public void execute () {
		}
       

        public void enter (BasicBoss boss) {
            
            LLLLLL.M++;
			self = boss;
			self.state = BasicBoss.BossState.Dead;
			self.m_Ani.SetTrigger("Dead");
            self.m_Ani.SetBool("Deads",true);
            self.tag = "Untagged";
			gameObject.GetComponent<CharacterController> ().enabled = false;
			Destroy (self.selfDie.DeadUI);
            if (self.selfDie.energy)
            {
                GameObject effect = Instantiate(self.selfDie.energy, self.selfDie.energytarget.transform.position, self.selfDie.energytarget.transform.rotation) as GameObject;//creating the effect
                effect.GetComponent<dielight>().energyincrease = self.selfDie.energyV;
            }
            if (self.selfDie.DeadEffect)
            {
                GameObject effect = Instantiate(self.selfDie.DeadEffect, transform.position, transform.rotation) as GameObject;//creating the effect
                Destroy(gameObject);
            }
            K = gameObject.GetComponents<MonoBehaviour>();
            
            //effect.transform.parent = self.energytarget.transform;
            foreach (BossAttackCollider weapon in self.bossAttackColliders)
            {
                weapon.on = false;

            }

            foreach (GameObject OBJ in self.selfDie.DeadDestroy)
            {
                Destroy(OBJ,1);
            }
            foreach (GameObject OBJ in self.selfDie.DeadInstantiate)
            {
                GameObject effect = Instantiate(OBJ, transform.position, transform.rotation) as GameObject;//creating the effect
            }

            foreach (GameObject OBJ in self.selfDie.DeadSetActice)
            {
                OBJ.SetActive(true);
            }

            foreach (MonoBehaviour Sp in K)
            {
             
                    Destroy(Sp);
               
            }
            self.m_Ani.ResetTrigger("Stiff");
            self.m_Ani.ResetTrigger("Stun");
            gameObject.AddComponent<BossHP1>();
        }
		
		public void exit ()	{
			Destroy(this);
		}
		
	}
}