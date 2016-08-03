using UnityEngine;
using System.Collections;
using Boss;

public class BigSwordCollide : MonoBehaviour {
	public GameObject parent;
	bool ishit = false;
	public GameObject Effect1;
    private Player player;
    Vector3 STtarget;

    
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
    }
    void OnTriggerEnter(Collider other) {
		
		GameObject Effect = Instantiate(Effect1, transform.position, transform.rotation) as GameObject;	
		Destroy (gameObject, 1);

		if (other.tag == "Boss") {

			  
				JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
				jsonObject.AddField("demage", player.bulletdem);
				//string
				jsonObject.AddField("type", "range");
			    
				//array
				JSONObject arr = new JSONObject(JSONObject.Type.ARRAY);
				jsonObject.AddField("effectList", arr);
			//Animator M_ami = other.GetComponent<Animator>();  //暫時用
			//M_ami.SetTrigger("Injured");//暫時被打動畫
				
			other.GetComponent<BasicBoss>().beDamaged(jsonObject);
		} else if (other.tag == "Enemy") {
			
			}

		
	}
	
	
	
}
