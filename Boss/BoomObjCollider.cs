using UnityEngine;
using System.Collections;

public class BoomObjCollider : MonoBehaviour {

    public string Anieffect;
    public float damage;
    public GameObject Effect;
    private Player player;
    //public float DieTime;

    // Use this for initialization

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Sword" && Ala.swordenter == true)
        {
                GameObject hurt = Instantiate(Effect, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                Destroy(gameObject);       
        }
    }

}
