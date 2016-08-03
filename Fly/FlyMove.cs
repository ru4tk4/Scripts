using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlyMove : MonoBehaviour {
     
    public Rigidbody Ship;
    public Animator ani;
    public bool InAir;
    public float AIrForce;
    public float MoveSpeed;
    public float RotaSpeed;
    public Vector3 eulerAngleVelocity;
    public Transform[] Guns;
    public Transform bulles;
    public float BulletSpeed;
    public GameObject[] fireheres;
    public GameObject cam;
    public Transform AttTarget;
  
    public float fire_CD;
    
   
  

    float fire_CD_Time;
    

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    // Use this for initialization
    void Start () {
        Ship = gameObject.GetComponent<Rigidbody>();
       // ani = gameObject.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked ;
       

    }

    void Update()
    {

       /* Ray();
       
        if (Input.GetMouseButton(0) && Time.time > fire_CD_Time)
        {
            fire_CD_Time = Time.time + fire_CD;
            foreach (GameObject firehere in fireheres)
            {
                Transform tMissile = F3DPool.instance.Spawn(bulles, firehere.transform.position + Vector3.up * 2, Quaternion.identity, null);
                //GameObject bulle = Instantiate(bulles, firehere.transform.position, firehere.transform.rotation) as GameObject;
                //bulle.GetComponent<WeaponsInertia>().InBu(AttTarget);
                //bulle.transform.parent = firehere.transform;
                
                    F3DMissile Missile = tMissile.GetComponent<F3DMissile>();
                        Missile.target = AttTarget;
                
                
                //bulle.GetComponent<Rigidbody>().AddForce((firehere.transform.forward + new Vector3(0,0,0)) * BulletSpeed,ForceMode.Impulse);
                //Ship.velocity.x, Ship.velocity.y, Ship.velocity.z
            }


        }
    */


        if (Input.GetKey(KeyCode.Q))
        {
           // ani.SetTrigger("RL");
        }
    }


    void Ray()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit ))
        {
            
             if (hit.collider.tag != "Player" )
             {
                foreach (Transform Gun in Guns)
                {
                    Gun.LookAt(hit.point);
                }
                   
                
             }
        }
    }


    // Update is called once per frame
    void FixedUpdate() {

        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                Ship.AddForce(transform.right * -MoveSpeed, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                Ship.AddForce(transform.right * MoveSpeed, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                Ship.AddForce(transform.up * MoveSpeed, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
            {
                Ship.AddForce(transform.up * -MoveSpeed, ForceMode.Force);
            }

            if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.A)
                | axes == RotationAxes.MouseXAndY| axes == RotationAxes.MouseX| axes == RotationAxes.MouseY)
            {

                float RL = Input.GetAxis("Mouse X");
                float UD = Input.GetAxis("Mouse Y");
                /*
                float RL = Input.GetAxis("FlyMoveRL");
                float UD = Input.GetAxis("FlyMoveUD");
                */
                Vector3 eulerMove = new Vector3(RotaSpeed *UD, RotaSpeed * -RL, 0);

                Quaternion deltaRotation = Quaternion.Euler(eulerMove * Time.deltaTime);
                Ship.MoveRotation(Ship.rotation * deltaRotation);
            }
        }
        else
        {
           if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.A)
                | axes == RotationAxes.MouseXAndY | axes == RotationAxes.MouseX | axes == RotationAxes.MouseY)
            {
                float RL = Input.GetAxis("Mouse X");
                float UD = Input.GetAxis("Mouse Y");
                /*float RL = Input.GetAxis("FlyMoveRL");               
                float UD = Input.GetAxis("FlyMoveUD");*/
                float AD = 0;
                Vector3 eulerMove = new Vector3(RotaSpeed*UD, RotaSpeed*RL, RotaSpeed*AD);

                Quaternion deltaRotation = Quaternion.Euler(eulerMove * Time.deltaTime);
                Ship.MoveRotation(Ship.rotation * deltaRotation);
            }

            if (Input.GetKey(KeyCode.W))
            {

                Ship.AddForce(transform.forward * MoveSpeed*2, ForceMode.Force);
                Ship.AddForce(transform.up * MoveSpeed * AIrForce, ForceMode.Force);
              

          
            }
            if (Input.GetKey(KeyCode.S))
            {
                Ship.AddForce(transform.forward * -MoveSpeed*0.5f, ForceMode.Force);
            }

            if (Input.GetKey(KeyCode.X))
            {
                Ship.ResetCenterOfMass();
            }
            if (Input.GetKey(KeyCode.A) )
            {
                Ship.AddForce(transform.right * -MoveSpeed, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.D) )
            {
                Ship.AddForce(transform.right * MoveSpeed, ForceMode.Force);
            }


        }
       
       


        
    }
}
