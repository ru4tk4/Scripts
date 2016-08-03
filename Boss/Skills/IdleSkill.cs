using UnityEngine;
using System.Collections;

namespace Boss {
	public class IdleSkill : MonoBehaviour, SkillState {
		private BasicBoss self;
		private SearchBehavior searchBehavior;
        
		public void execute () {
			searchBehavior.execute();
            
        }
		
		public void enter (BasicBoss boss) {
           
            self = boss;
            if (self.IFIK == true)
            {
                self.IKSwitch(false);
            }
            searchBehavior = new SearchBehavior(boss, self.playerLayer, delegate(Transform target) {
                self.target = target;
                if (Vector3.Distance(self.transform.position, target.position) < self.selfDistance.look&& Vector2.Distance(new Vector2(self.transform.position.y,0),new Vector2(target.position.y,0))<2)
                {           
                    self.changeState(gameObject.AddComponent<TraceSkill>());
                }
				
			});

            if (self.selfpatrol.pathOnOff == true)
            {
                gameObject.AddComponent<PathFollow>();
            }

           
            self.m_Ani.SetInteger("Move", 0);
			self.state = BasicBoss.BossState.Idle;

		}
		
		public void exit ()	{
            
            if (self.selfpatrol.pathOnOff == true)
            {
                Destroy(gameObject.GetComponent<PathFollow>());
            }
            Destroy(this);

		}

	}
}