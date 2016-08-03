using UnityEngine;
using System.Collections;

namespace Boss {
	public class BossHandCollider : MonoBehaviour {

        
       
        public GameObject Effect;
        static public bool att = false;
        //public int SuicideV;
        //public GameObject SuicideObj;
        //public GameObject[] monster;
        void LateUpdate()
        {
            RaycastHit hit;
            if (att == true)
            {
                if (Physics.Raycast(gameObject.transform.position, Vector3.up * -1, out hit, 10f, 1023))

                {
                    if (Vector3.Distance(transform.position, hit.point) < 7)
                    {
                        GameObject bulle1141 = Instantiate(Effect, hit.point, new Quaternion(0, 0, 0, 0)) as GameObject;
                    }
                }
            }
        }


        
	}
}