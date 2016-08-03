using UnityEngine;
using System.Collections;

namespace Boss {
	public class JumpBehavior {
		BasicBoss self;
        GameObject OBJ;
		public JumpBehavior (BasicBoss boss) {
			self = boss;
		}
		
        public void AttackJump()
        {
            
            
        }

		public void jumpToPosition(Transform gameObject) {
			Vector3 distance = (gameObject.transform.position)- self.transform.position;
			
			Vector3[] path = new Vector3[] { new Vector3(self.transform.position.x + distance.x * 0.75f,  
													   gameObject.transform.position.y + 5f,
				                                        self.transform.position.z + distance.z * 0.75f),
											new Vector3(gameObject.transform.position.x, 
											            gameObject.transform.position.y,
											            gameObject.transform.position.z ) };
            
			
			Hashtable hashtable = new Hashtable();
			hashtable.Add("path", path);
			
			hashtable.Add("easeType", "linear");
			
			hashtable.Add("speed", 40);
			hashtable.Add("oncomplete", "Land");
			
			iTween.MoveTo(self.gameObject, hashtable);
			
		}
		
		public void jumpImpactCheck(JSONObject info) {
			float distance = Vector3.Distance( self.target.position , self.transform.position);
			if (distance < 5.5f) {
				Debug.Log(self.target.name);
				//self.target.GetComponent<Player>().underBossAttack(info,false);
			}
			
		}
		
	}
}