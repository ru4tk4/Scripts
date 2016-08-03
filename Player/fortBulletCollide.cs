using UnityEngine;
using System.Collections;
using Boss;

public class fortBulletCollide : MonoBehaviour {
	
	
	public GameObject Effect1;
    public int demage;
    

    
	void Start() {
		
		Destroy(gameObject, 10);        
        
    }

    void Update()
    {
        
       
    }
    void OnTriggerEnter(Collider other) {
		int enemyLayer = 1 << 9;
        if (Effect1)
        {
            GameObject Effect = Instantiate(Effect1, transform.position, transform.rotation) as GameObject;
        }
		Destroy (gameObject, 1);

		if (other.tag == "Boss") {

			  
				JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
				jsonObject.AddField("demage", demage);
				//string
				jsonObject.AddField("type", "range");
			    
				//array
				JSONObject arr = new JSONObject(JSONObject.Type.ARRAY);
				jsonObject.AddField("effectList", arr);
            //Animator M_ami = other.GetComponent<Animator>();  //暫時用
            //M_ami.SetTrigger("Injured");//暫時被打動畫

            if (other.GetComponent<BasicBoss>())
            {
                other.GetComponent<BasicBoss>().beDamaged(jsonObject);
            }
            else if(other.GetComponent<SiteDamage>())
            {
                other.GetComponent<SiteDamage>().beDamaged(jsonObject);
            }
        }

		
	}
	
	
	
}
