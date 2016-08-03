using UnityEngine;
using System.Collections;
using System;

namespace Boss {
	public class SGunManager : BasicBoss {
		
		void Start() {
			//Defualt Search
			base.Start();
			getBossData("Zombie");
			currentState = gameObject.AddComponent<IdleSkill>();
			currentState.enter(this);
			
		}
		
		protected void FixedUpdate () {
            if (state != BasicBoss.BossState.Dead)
            {
                currentState.execute();
                base.FixedUpdate();
            }
		}
		
		public override void beDamaged(JSONObject json) {
			base.beDamaged(json);
			
		}
		
		
	}
}