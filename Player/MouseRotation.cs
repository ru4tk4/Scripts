using UnityEngine;
using System.Collections;

public class MouseRotation : MonoBehaviour 
{
    public float kkkkk;
    public float KK = 1;
    public GameObject ttt;
    public float lockD = 20;
    public Camera camera;
    public Transform g;
    public LockMonter LM;
    static public bool camoff = true;
    public Transform target;
    public Animator Ani;
	public static float distance = 5.0f;
	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;
	
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

    public float GunMin = .5f;

    public float distanceMin = .5f;
	public float distanceMax = 15f;
    public float distanceMinMin = 15f;
    public float distanceMaxMax = 15f;

    public float yMargin;

	public bool NeedSmooth ;
	public float smooth = 0.0f;
	
	public bool LimitX = false;
	public static float x = 0.0f;
	public bool LimitY = false;
	public static float y = 0.0f;

	public float OCCShooth;
    public Vector2 startXY;
	public Vector2 ShowXY;
	public float distanceShooth;
	public float distanceShooth1;
	public float distanceShoothDecreasing;
	public float PunchValue = 0f;
	public  Vector3 cc=new Vector3(0, 0.1f, 0);
	private float yVelocity = 0.0F;
    bool lockkk;
    bool lockzero;
    public RectTransform LockUi;
    float LockUp2;
    

    void Start () 
	{
		Hashtable args = new Hashtable();
		args.Add("oncomplete", "AnimationEnd");
		//Vector3 angles = transform.eulerAngles;
		x = startXY.x;
		y = startXY.y;
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
	
    void Update()
    {
       
        
       

        if (Input.GetButtonDown("Mouse2") || Input.GetKeyDown(KeyCode.Mouse2))
        {
           

            if (lockkk == true&& lockzero == false)
            {
                lockkk = false;
                LockUi.gameObject.SetActive(false);
                g = null;
            }
            else
            {
              
                float D = 10000;
                if (LM.monters.Length != 0)
                {
                    foreach (GameObject gg in LM.monters)
                    {
                        if (gg == null|| gg.GetComponent<Boss.BasicBoss>() == false)
                        {
                            LM.mm.Remove(gg);
                           
                        }                     
                        else
                        {                           
                            float k = 0;
                            k = KKKKK.DistanceOfPointToVector(camera.transform.position, camera.transform.position + (camera.transform.forward * lockD), gg.transform.position);
                            if (k < D)
                            {                               
                                D = k;
                                kkkkk = k;
                                g = gg.transform;
                                LockUp2 = gg.GetComponent<Boss.BasicBoss>().LockUp;
                                lockzero = false;
                                lockkk = true;
                                LockUi.gameObject.SetActive(true);
                              //  print("1");
                            }
                        }            
                    }                 
                }
                else 
                {
                    lockzero = true;
                    lockkk = true;
                    LockUi.gameObject.SetActive(false);
                    g = null;
                   // print("4");
                }
            }            
        }

        if (lockzero == false)
        {
            if (g == null || (g.tag != "Player" & g.GetComponent<Boss.BasicBoss>() == false) || Vector3.Distance(g.transform.position, transform.position) > lockD)
            {
                lockkk = false;
                LockUi.gameObject.SetActive(false);
                g = null;
               // print("3");
            }
            else
            {
                Vector3 p = new Vector3(g.position.x, g.position.y + LockUp2, g.position.z);
                LockUi.position = camera.WorldToScreenPoint(p);
                Vector3 pos = new Vector3(g.position.x, g.position.y + 1.5f, g.position.z);
                target.LookAt(g.position);
            }
        }
    }
   


    void LateUpdate () 
	{

        

            /*if (PunchValue >= 1) {

                iTween.ShakePosition(gameObject, cc, 1);
                print("1");

            }*/


            ShowXY = new Vector2(x,y);
		if (target) 
		{
            DrawCollderLine();
            if (camoff==true) {
                
                if (lockkk == true)
                {
                    if (lockzero == false)
                    {
                        x = Mathf.SmoothDampAngle(x, target.rotation.eulerAngles.y, ref yVelocity, smooth);
                    }
                    else
                    {
                        x = Mathf.SmoothDampAngle(x, Ani.transform.rotation.eulerAngles.y, ref yVelocity, smooth);

                        if (Mathf.Abs(x - Ani.transform.rotation.eulerAngles.y) < 0.5)
                        {
                            lockkk = false;
                            lockzero = false;
                        }
                        
                    }
                }
                else
                {
                    if (!LimitX)

                    {
                        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;

                    }
                }
                if (!LimitY)

                {

                    y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

                    y = ClampAngle(y, yMinLimit, yMaxLimit);

                }
            }
           
            if (x > 360)
			{
				x -= 360;
			}
			else if (x < 0)
			{
				x += 360;
			}
           
            /* if ( Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D))
             {
                 x = Mathf.SmoothDampAngle(x, Ani.gameObject.transform.rotation.eulerAngles.y, ref yVelocity, KK);

             }*/
            Quaternion rotation;
            
           
            rotation = Quaternion.Euler(y, x, 0);

            //distanceMax = Mathf.Clamp(distanceMax - Input.GetAxis("Mouse ScrollWheel")*Time.deltaTime*60, distanceMinMin, distanceMaxMax);
            distanceMax = distanceMaxMax*Ani.GetFloat("att01");
			Vector3 negDistance;
			Vector3 position = Vector3.zero;

			

			negDistance = new Vector3(0.0f, 0.0f, -distance);


			if (NeedSmooth)
			{
				//position = Vector3.Lerp(transform.position,rotation * negDistance + target.position, Time.deltaTime * smooth);
				position.x = (rotation * negDistance).x + target.position.x;
				position.z = (rotation * negDistance).z + target.position.z;

				if (CheckYMargin())
					position.y = Mathf.Lerp(transform.position.y , rotation.y * negDistance.y + target.position.y , Time.deltaTime * smooth);
				else
				//	position.y = (rotation * negDistance).y + target.position.y;
					position.y = transform.position.y;
			}
			else
			{
				//position = rotation * negDistance + target.position;
				position.x = (rotation * negDistance).x + target.position.x;
				position.y = (rotation * negDistance).y + target.position.y;
				position.z = (rotation * negDistance).z + target.position.z;
			}
        /*if(PlayerMove.SightSwitch == false){
            transform.rotation = rotation;
        }else{
            //transform.rotation = target.transform.rotation;
            transform.rotation = rotation;
        }*/
        transform.rotation = rotation;
        transform.position = position;
           
			//transform.LookAt(testLock.position);//
		}
	}
	
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - target.position.y) > yMargin;
	}
    float DD;
	private Vector3 DrawCollderLine()
	{
		Debug.DrawLine(transform.position , transform.position + transform.forward*5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.forward*-5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.right*5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.right*-5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.up*5f , Color.red);
		Debug.DrawLine(transform.position , transform.position + transform.up*-5f , Color.red);

		RaycastHit hit;

      /*  if (Physics.Linecast (transform.position, transform.position + transform.forward * -3f, out hit, 1023) && CheckHitTag (hit.collider.tag)) {
			distance = Vector3.Distance (target.position, hit.point) - OCCShooth;

		}
		if (Physics.Linecast (transform.position, transform.position + transform.right * 3f, out hit,1023) && CheckHitTag (hit.collider.tag)) {
			distance = Vector3.Distance (target.position, hit.point) - OCCShooth;

		}
		if (Physics.Linecast(transform.position , transform.position + transform.right*-3f , out hit,1023) && CheckHitTag(hit.collider.tag)){
			distance = Vector3.Distance (target.position,hit.point)-OCCShooth;
		}
		if (Physics.Linecast (transform.position, transform.position + transform.up * 3f, out hit,1023) && CheckHitTag (hit.collider.tag)) {
			distance = Vector3.Distance (target.position, hit.point) - OCCShooth;

		}
		if (Physics.Linecast (transform.position, transform.position + transform.up * -2f, out hit,1023) && CheckHitTag (hit.collider.tag)) {
			distance = Vector3.Distance (target.position, hit.point) - OCCShooth;

		}*/
        if(PlayerMove.SightSwitch == false)
        {
            DD = distanceMaxMax;
        }
        else
        {
            DD = GunMin;
        }

        if (Physics.Raycast(target.position,transform.forward * -1, out hit,DD+OCCShooth, 1023) && CheckHitTag(hit.collider.tag)) {


         
           // distance = Mathf.SmoothDampAngle(distance, (Vector3.Distance(target.position, hit.point) - OCCShooth), ref yVelocity, smooth);
          
               distance = Vector3.Distance(target.position, hit.point) - OCCShooth;     

        }
        else
        if (distance < distanceMax && PlayerMove.SightSwitch == false)
        {
            distance = Mathf.SmoothDampAngle(distance, distanceMax, ref yVelocity, smooth);
            
            //distance += 0.1f;

        }
        else
        if (distance != GunMin && PlayerMove.SightSwitch == true)
        {
            distance = Mathf.SmoothDampAngle(distance, GunMin, ref yVelocity, smooth);
            //distance -= 0.1f;

        }


        if (distance < distanceMin)
        {
            distance = distanceMin;
            distanceShooth = distanceShooth1;
        }
      


        if (distance > distanceMax)
        {
            distance = distanceMax;
            distanceShooth = distanceShooth1;
        }

        return hit.point;
	}
	private bool CheckHitTag(string tag)
	{
		if (tag == "Player" | tag == "Boss"   | tag == "Sword"  | tag == "BossSword" | tag == "MainCamera")
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public void punch(){

		PunchValue++;

	}
}
