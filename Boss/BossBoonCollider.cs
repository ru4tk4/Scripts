using UnityEngine;
using System.Collections;

public class BossBoonCollider : MonoBehaviour {

    public string Anieffect;
    public float damage;
    public GameObject Effect;
    public float DieTime1 = 0.5f;
    //public int SuicideV;
    //public GameObject SuicideObj;
    //public GameObject[] monster;
    void Start()
    {
        transform.parent = transform;
        Destroy(gameObject, DieTime1);
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
                other.gameObject.GetComponent<Player>().underAttack(damage, Anieffect);
                Destroy(gameObject);
        }
        
    }
}
