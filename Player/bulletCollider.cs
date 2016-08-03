using UnityEngine;
using System.Collections;
using Boss;

public class bulletCollider : MonoBehaviour {
    public float bulletdem;
    
	bool ishit = false;
	public GameObject Effect1;
    
    Vector3 TagPos;
    Vector3 TagNol;
    Collider TagObj;
    public GameObject BulletHole;
   
    bool Go;
   
    
	void Start() {
		
		Destroy(gameObject, 10);
        
       
    }

    void Update()
    {
        FireRay();
    }

    void FireRay()
    {
        RaycastHit hit;
       if (Vector3.Distance(gameObject.transform.position, TagPos) < 1)
        {
            BulletEnter(TagObj);
            //transform.forward = TagNol;
            if (TagObj.tag != "Boss")
            {
                GameObject BulletHoleEffect = Instantiate(BulletHole, TagPos, transform.rotation) as GameObject;
                BulletHoleEffect.transform.forward = TagNol;
            }
            else
            {
                if (Effect1)
                {
                    GameObject Effect = Instantiate(Effect1, TagPos, transform.rotation) as GameObject;
                    transform.forward = TagNol;
                }
            }
        }
        else
           
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit,30f, 1023))
        {

            //GameObject BulletHoleEffect = Instantiate(BulletHole, transform.position, transform.rotation) as GameObject;
            TagPos = hit.point;
            TagObj = hit.collider;
            TagNol = hit.normal;
            if (Vector3.Distance(gameObject.transform.position, hit.point) < 0.5)
            {
                BulletEnter(hit.collider);

                // transform.forward = hit.normal;
                if (hit.collider.tag != "Boss")
                {
                    GameObject BulletHoleEffect = Instantiate(BulletHole, hit.point, transform.rotation) as GameObject;
                    BulletHoleEffect.transform.forward = hit.normal;
                }
                else
                {
                    if (Effect1)
                    {
                        GameObject Effect = Instantiate(Effect1, hit.point, transform.rotation) as GameObject;
                        Effect.transform.forward = hit.normal;
                    }
                }
            }
           
        

        }
    }

    void BulletEnter(Collider other) {
	
        if(other.tag != "Sword") {

            if (other.tag == "Boss") {

                JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
                jsonObject.AddField("demage", bulletdem);
                //string				
                jsonObject.AddField("type", "range");
                JSONObject arr = new JSONObject(JSONObject.Type.ARRAY);
                jsonObject.AddField("effectList", arr);
                //Animator M_ami = other.GetComponent<Animator>();  //暫時用
                //M_ami.SetTrigger("Injured");//暫時被打動畫
                if (other.GetComponent<BasicBoss>())
                {
                    other.GetComponent<BasicBoss>().beDamaged(jsonObject);
                }
                else
                {
                    other.GetComponent<SiteDamage>().beDamaged(jsonObject);
                }

            }
            /*if (Effect1) {
                GameObject Effect = Instantiate(Effect1, transform.position, transform.rotation) as GameObject;
            }*/
            
            Destroy(gameObject);
        }        

    }
	
	
	
}
