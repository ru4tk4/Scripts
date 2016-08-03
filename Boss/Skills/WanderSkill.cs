﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Boss {
public class WanderSkill : MonoBehaviour, SkillState{
		private BasicBoss self;
		private MoveBehavior moveBehavior;
		private SearchBehavior searchBehavior;
		
		
		#region SkillState implementation
		public void execute () {
			moveBehavior.turnToDirection(2f);
			moveBehavior.moveToPoint();
			searchBehavior.execute();
			
		}
		
		public void enter (BasicBoss boss) {
			self = boss;
			moveBehavior = new MoveBehavior(boss, self.maxWalkVelocity, delegate {
				moveBehavior.setWayPoint();
			});
			
			searchBehavior = new SearchBehavior(boss, self.playerLayer, delegate(Transform target) {
				self.target = target;
				self.changeState(gameObject.AddComponent<TraceSkill>());
			});
			
			
			self.state = BasicBoss.BossState.Move;

			moveBehavior.setWayPoint();			
		}
		
		public void exit ()	{
			Destroy(this);
		}
		#endregion
		
		
		
	}
}