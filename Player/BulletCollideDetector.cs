using UnityEngine;
using System.Collections;
using Boss;

public class BulletCollideDetector : MonoBehaviour {
	public GameObject parent;
	bool ishit = false;
	public GameObject Effect1;
    private Player player;
    public Vector3 TagPos;
    public Vector3 TagNol;
    public Collider TagObj;
    public GameObject BulletHole;
    Vector3 STtarget;
    bool Go;
    int Lay = 1 << 8;
    
	void Start() {
		parent = transform.root.gameObject;
		Destroy(gameObject, 10);
        player = GameObject.Find("Albert2").GetComponent<Player>();
        STtarget = gameObject.transform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(STtarget, gameObject.transform.position);
        if(distance > player.ShootRange )
        {
            GameObject Effect = Instantiate(Effect1, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
        }
       /* if(Vector3.Distance(gameObject.transform.position,TagPos) < 0.5)
        {
            GameObject BulletHoleEffect = Instantiate(BulletHole, transform.position, transform.rotation) as GameObject;
        }*/
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
                jsonObject.AddField("demage", (int)(player.bulletdem * player.bulletRato*player.ES_bulletRato));
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
