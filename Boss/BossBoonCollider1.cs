using UnityEngine;
using System.Collections;

public class BossBoonCollider1 : MonoBehaviour {

    public string Anieffect;
    public float damage;
    public GameObject Effect;
    public float DieTime;
    //public int SuicideV;
    //public GameObject SuicideObj;
    //public GameObject[] monster;
    void Start()
    {
        transform.parent = transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {

            //Deduct enemy's hp
            if (Effect)
            {
                GameObject bulle1141 = Instantiate(Effect, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                              
            }
           // other.gameObject.GetComponent<Player>().underAttack(damage, Anieffect);
           // Destroy(gameObject, DieTime);
        }
        
    }
}
