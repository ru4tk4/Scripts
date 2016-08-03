using UnityEngine;
using System.Collections;

public class FlyHP : MonoBehaviour {
    public int HP;
    int MaxHP;
    public GameObject Fire;
    public GameObject Fire2;
    public ParticleSystem BoonFS;
    public GameObject Boon;
    bool one;
    // Use this for initialization
    void Start () {
        MaxHP = HP;
	}
	
	// Update is called once per frame
	void Update () {

        if (HP  <= 0&&one==false)
        {
            Instantiate(Boon, transform.position, transform.rotation);
            Destroy(gameObject, 0.5f);
            one = true;
        }

        /*if (HP / MaxHP < 0.5)
        {
            
                Fire.active =true;
                
        }
        else if (HP / MaxHP < 0.2)
        {
            
                Fire2.active = true;
            
        }
        else if (HP / MaxHP <= 0)
        {
            Instantiate(Boon, transform.position, transform.rotation);
            Destroy(gameObject, 0.5f);
        }*/
	}

    public void Injured(int De)
    {



    }


}
