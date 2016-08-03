using UnityEngine;
using System.Collections;

public class fort : MonoBehaviour {

    public bool automatic = false;
    public int tt = 99999999;
    int ttt;
    public Transform hub;           // Turret hub 
    public Transform barrel;
    public Transform Target;
    public Transform[] FireOBJ;
    public Animator Arrow;
    float hubAngle, barrelAngle;

    public GameObject B_bullet;
    public GameObject B_bulletFire;
    public float B_bulletSpeed;
    public float CD;
    float fire_CD_Time;
    // Use this for initialization

    Vector3 ProjectVectorOnPlane(Vector3 planeNormal, Vector3 vector)
    {
        return vector - (Vector3.Dot(vector, planeNormal) * planeNormal);
    }

    // Get signed vector angle
    float SignedVectorAngle(Vector3 referenceVector, Vector3 otherVector, Vector3 normal)
    {
        Vector3 perpVector;
        float angle;

        perpVector = Vector3.Cross(normal, referenceVector);
        angle = Vector3.Angle(referenceVector, otherVector);
        angle *= Mathf.Sign(Vector3.Dot(perpVector, otherVector));

        return angle;
    }


    void Start () {
        ttt = tt;
	}
	
	// Update is called once per frame
	void Update () {

        if (automatic ==true)
        {
            FortMove();
            FortFire();
        }
        else

        if(fortEnter.fortopen == true)
        {
            FortMove();
            if(Input.GetButton("Fire1") )
            FortFire();
        }
       
        

    }


    void FortFire()
    {
        if (Time.time > fire_CD_Time && NewerUI.Gamepaused == false)
        {
            if(Arrow)
            Arrow.SetTrigger("Open");
            FireGun(FireOBJ[Random.Range(0, 4)]);
            fire_CD_Time = Time.time + CD;
            tt--;
            if (tt <= 0)
            {
                tt = ttt;
                gameObject.SetActive(false);
            }
        }

        else
        {
            if(Arrow)
            Arrow.SetTrigger("Close");
        }
    }

    void FireGun(Transform B_FireObj)
    {
        //Vector3 playerPOS = new Vector3(GameObject.Find("Albert2").transform.position.x, GameObject.Find("Albert2").transform.position.y+2, GameObject.Find("Albert2").transform.position.z) ;
        //self.B_FireObj.transform.LookAt(playerPOS);
        /*self.B_bullet.transform.position = self.B_FireObj.transform.position;
        self.B_bullet.active =true;*/
        
        GameObject bulle = Instantiate(B_bullet, B_FireObj.transform.position, B_FireObj.transform.rotation) as GameObject;
        GameObject bulle1 = Instantiate(B_bulletFire,B_FireObj.transform.position, B_FireObj.transform.rotation) as GameObject;
        bulle.GetComponent<Rigidbody>().AddForce((B_FireObj.transform.forward + new Vector3(Random.Range(-0.1f,0.1f), Random.Range(-0.1f, 0.1f), 0)) * B_bulletSpeed);


    }


    void FortMove()
    {
        Vector3 headingVector = ProjectVectorOnPlane(hub.up, Target.position - hub.position);
        Quaternion newHubRotation = Quaternion.LookRotation(headingVector);

        // Check current heading angle
        hubAngle = SignedVectorAngle(transform.forward, headingVector, Vector3.up);

        // Limit heading angle if required
        /*if (hubAngle <= -60)
            newHubRotation = Quaternion.LookRotation(Quaternion.Euler(0, -60, 0) * transform.forward);
        else if (hubAngle >= 60)
            newHubRotation = Quaternion.LookRotation(Quaternion.Euler(0, 60, 0) * transform.forward);
            */
        // Apply heading rotation
        hub.rotation = Quaternion.Slerp(hub.rotation, newHubRotation, Time.deltaTime * 5f);

        // Calculate elevation vector and rotation quaternion
        Vector3 elevationVector = ProjectVectorOnPlane(hub.right, Target.position - barrel.position);
        Quaternion newBarrelRotation = Quaternion.LookRotation(elevationVector);

        // Check current elevation angle
        barrelAngle = SignedVectorAngle(hub.forward, elevationVector, hub.right);

        // Limit elevation angle if required
        if (barrelAngle < -50&& automatic == false)
            newBarrelRotation = Quaternion.LookRotation(Quaternion.AngleAxis(-50f, hub.right) * hub.forward);
        else if (barrelAngle > 15 && automatic == false)
            newBarrelRotation = Quaternion.LookRotation(Quaternion.AngleAxis(15f, hub.right) * hub.forward);

        // Apply elevation rotation
        barrel.rotation = Quaternion.Slerp(barrel.rotation, newBarrelRotation, Time.deltaTime * 5f);
    }
}
