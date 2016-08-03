using UnityEngine;
using System.Collections;

public class FlyMoster : MonoBehaviour {
    public int HP;
    public GameObject player;
    public Animator ani;
    public Rigidbody moster;
    public float MoveSpeed;
    public float RotaSpeed;
    public Vector3 eulerAngleVelocity;
    public GameObject bulles;
    public float BulletSpeed;
    public GameObject[] fireheres;
    public float fire_CD;
    public F3DFXController fire;
    float fire_CD_Time;

    // Use this for initialization
    void Start () {
        moster = gameObject.GetComponent<Rigidbody>();
       // ani = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float D = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (D > 40)
        {
            gameObject.transform.LookAt(player.transform);
            moster.AddForce(transform.forward * MoveSpeed, ForceMode.Force);
        }
        else
        {
            if (Random.Range(0, 9) > 4)
            {
                moster.AddForce(transform.right * -MoveSpeed*0.2f, ForceMode.Force);
            }
            if (Random.Range(0, 9) > 4)
            {
               // ani.SetTrigger("RL");
            }

            /*if (Random.Range(0, 9) > 4)
            {
                gameObject.transform.LookAt(player.transform);
                moster.AddForce(transform.forward * -MoveSpeed, ForceMode.Force);
            }
            else
            {
                moster.AddForce(transform.forward * MoveSpeed*5, ForceMode.Force);
            }*/
            gameObject.transform.LookAt(player.transform);
            moster.AddForce(transform.forward * -MoveSpeed, ForceMode.Force);
        }

        

        if (D<550 && Time.time > fire_CD_Time)
        {
            fire_CD_Time = Time.time + fire_CD;
            fire.Fire();
            /*foreach (GameObject firehere in fireheres)
            {
                
                GameObject bulle = Instantiate(bulles, firehere.transform.position, firehere.transform.rotation) as GameObject;
                //bulle.transform.parent = firehere.transform;
                bulle.GetComponent<Rigidbody>().AddForce((firehere.transform.forward + new Vector3(0, 0, 0)) * BulletSpeed, ForceMode.Impulse);
                //Ship.velocity.x, Ship.velocity.y, Ship.velocity.z
            }*/
        }
        else
        {
            fire.Stop();
        }




	}
}
