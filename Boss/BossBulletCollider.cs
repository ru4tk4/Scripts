using UnityEngine;
using System.Collections;

namespace Boss {
	public class BossBulletCollider : MonoBehaviour {

        
        public string Anieffect;
        public float damage;
        public GameObject Effect;
        public float DieTime;
        //public int SuicideV;
        //public GameObject SuicideObj;
        //public GameObject[] monster;

        void OnTriggerEnter(Collider other) {
            if (Effect)
            {
                GameObject bulle1141 = Instantiate(Effect, gameObject.transform.position, gameObject.transform.rotation) as GameObject;                
            }
            if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Input_Handler>().currentState != Player.State.Dead)
            {
                other.gameObject.GetComponent<Player>().underAttack(damage, Anieffect);
                
            }
            Destroy(this);
            Destroy(gameObject, DieTime);
            
        }

        
	}
}