using UnityEngine;
using System.Collections;

public class Lightening : MonoBehaviour {
    public GameObject LL;
    public float tt =1;
    Vector2 F;
    Vector3 K;

    // Use this for initialization
    void Start () {

        InvokeRepeating("LighteningFire", tt, tt);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LighteningFire()
    {

        float Pie = 50;
        int V = 20;


        K = gameObject.transform.position;
        Pie = 50;
        V = Random.Range(1,5);



        for (int i = 0; i < V;)
        {
            F = Random.insideUnitCircle * Pie;
            Vector3 V3 = new Vector3(K.x + F.x, gameObject.transform.position.y+5, K.z + F.y);

            RaycastHit hit;

            if (Physics.Raycast(V3, transform.up*-1, out hit, 50f, 1))
            {

                GameObject Magic = Instantiate(LL, hit.point, gameObject.transform.rotation) as GameObject;
               

            }

            i++;


        }


    }


    void Ray()
    {
        
    }

}
