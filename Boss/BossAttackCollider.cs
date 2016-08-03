using UnityEngine;
using System.Collections;

namespace Boss {
	public class BossAttackCollider : MonoBehaviour {
		public bool on = false;
        
		public JSONObject attackInfo;


		void OnTriggerStay(Collider other) {
			if(on==true && other.gameObject.tag == "Player" && other.gameObject.GetComponent<Input_Handler>().currentState != Player.State.Dead) {
				on = false;
                
				//Deduct enemy's hp
				other.gameObject.GetComponent<Player>().underBossAttack(attackInfo,false);
			}



		}
	}
}