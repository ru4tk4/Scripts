using UnityEngine;
using System.Collections;
using System;

namespace Boss {
	public class Z_Skull : BasicBoss {
        int canEndureDemage = 200;
        void Start() {
			//Defualt Search
			base.Start();
			getBossData("Z_Skull");
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
            if (state != BossState.Dead)
            {

                base.beDamaged(json);
                damagebehavior.golemEffect(json.GetField("demage").n, canEndureDemage);
            }
        }


    }
}