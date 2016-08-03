using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Boss {

	public class MoveBehavior  {
		public Vector3 waypoint;
		BasicBoss self;
		Action reachCallback;
		int mSpeed;
		
		public MoveBehavior (BasicBoss boss, int speed, Action callback) {
			self = boss;
			reachCallback = callback;
			mSpeed = speed;
			self.m_Ani.SetInteger("Move", 1);
		}

        public List<Vector3> getSpawnPos()
        {
            List<Vector3> spwanPoints = new List<Vector3>();
            float randomNumX = UnityEngine.Random.Range(-self.spawnRange, self.spawnRange);
            float randomNumZ = UnityEngine.Random.Range(-self.spawnRange, self.spawnRange);
            spwanPoints.Add(new Vector3(self.transform.position.x + randomNumX, self.transform.position.y + 30, self.transform.position.z + randomNumZ));
            spwanPoints.Add(new Vector3(self.transform.position.x + randomNumX, self.transform.position.y - 10, self.transform.position.z + randomNumZ));
            return spwanPoints;
        }

        public void setWayPoint() {
			List<Vector3> points = getSpawnPos();
			RaycastHit hitInfo;
			if (Physics.Linecast(points[0], points[1], out hitInfo, self.terrainLayer)) {
				waypoint = hitInfo.point;
			} else {
				setWayPoint();
			}
		}



		public void checkOutOfVision() {
			float distance = Vector3.Distance(waypoint, self.transform.position);
			if (distance > self.loseVisionRange) {
				//self.changeState(self.gameObject.AddComponent<WanderSkill>());
			}
		}
		
		public void turnToDirection(float delay) {
			
			Vector3 normalizedDirection = Vector3.Normalize(new Vector3(waypoint.x, self.transform.position.y, waypoint.z) -self.transform.position);
			Quaternion newRotation = Quaternion.LookRotation(normalizedDirection);
			self.transform.rotation = Quaternion.Slerp(self.transform.rotation, newRotation, self.turndelay * Time.deltaTime);
		}			
		
		public void moveToPoint() {
				float distance = Vector3.Distance(waypoint, self.transform.position);
				Vector3 moveDir = self.transform.forward * Time.deltaTime * mSpeed;
				if ( distance < 7) {
					reachCallback();
				}
				if (distance > 2 ) {
					self.m_CharCtrl.Move( moveDir  + new Vector3(0,self.MoveDir.y,0));
				} 		 		
		}

        public void NMAexecute()
        {
            if (self.NMA != null)
            {
                self.NMA.destination = self.target.position;
                self.NMA.velocity = new Vector3(0, 0, 0);
                if (NewerUI.Gamepaused == true)
                {
                    self.NMA.enabled = false;
                }
                else
                {
                    self.NMA.enabled = true;
                }
            }
        }

        public void NMAenter()
        {
            if (self.NMA != null)
            {
                self.NMA.enabled = true;
                self.NMA.velocity = new Vector3(0, 0, 0);
            }

        }
        public void NMAexit()
        {
              if (self.NMA != null)
            {

                self.NMA.enabled = false;
            }

        }


    }
}