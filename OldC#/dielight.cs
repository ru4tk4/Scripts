using UnityEngine;
using System.Collections;

public class dielight : MonoBehaviour
{

    public GameObject target;
    public Player player;
	public GameObject Effect1;
    


    public int energyincrease;
	
	public float speed = 25;
	private float distanceToTarget;
	private bool move = true;
    

    public float radian = 0; // 弧度
    public float perRadian = 0.03f; // 每次变化的弧度
    public float radius;
    public float radiusMAX;
    private Vector3 oldPos;


    public bool Off;
    public float WaitTime;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("Albert2");

        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        player = target.GetComponent<Player>();
        oldPos = transform.position;
        StartCoroutine(Time1(WaitTime));

        
    }

    IEnumerator Time1(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Off = true;
        //.MoveTo();
        //StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
	{

		while (move)
		{

			Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y+1.7f, target.transform.position.z);
            transform.LookAt(targetPos);
			//float angle = Mathf.Min(1, Vector3.Distance(transform.position, targetPos) / distanceToTarget) * 45;
            //transform.rotation = transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
			float currentDist = Vector3.Distance(transform.position, target.transform.position);

			if (currentDist < 0.5f)
				move = false;
            transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            speed++;
			yield return null;

		}
	}
	
	// Update is called once per frame
	void Update () {

		
	}
	void LateUpdate () 
	{
        
            radian += perRadian;// 弧度每次加0.03
                                //perRadian = Random.Range (0.01, 0.03);

            float yradius = Random.Range(radius, radiusMAX);


            float dy = Mathf.Cos(radian) * radiusMAX;
            transform.position = oldPos + new Vector3(0, dy, 0);
        
    }

	void OnTriggerEnter(Collider other) {
        if (Off == true)
        {
            if (other.tag == "Player")
            {

                gameObject.transform.parent = other.transform;
                player.energy += energyincrease;               
                GameObject Effect = Instantiate(Effect1, target.transform.position, target.transform.rotation) as GameObject;
                Effect.transform.parent = target.transform;
                Destroy(gameObject);


            }
        }
	}



}
