using UnityEngine;
using System.Collections;
using System;

namespace Boss {
	public class ZombieManager : BasicBoss {
		
		void Start() {
			//Defualt Search
			base.Start();
			getBossData("Zombie");
			currentState = gameObject.AddComponent<IdleSkill>();
			currentState.enter(this);
			
		}
		
		protected void FixedUpdate () {
            if (state != BossState.Dead)
            {
                currentState.execute();
                base.FixedUpdate();
            }
		}
		
		public override void beDamaged(JSONObject json) {
            if (state != BossState.Dead)
            {
                base.beDamaged(json);
            }
			
		}
		
		
	}
}