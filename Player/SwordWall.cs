using UnityEngine;
using System.Collections;

public class SwordWall : MonoBehaviour {
    public Transform SwordTap;
    Vector3 TapPos;
    public RootMotion.FinalIK.Demos.HitReaction IKHR;
    bool OP=true;

	// Use this for initialization
	void Start () {
        TapPos = SwordTap.position;
    }
	
	// Update is called once per frame
	void Update () {
        Ray((TapPos - SwordTap.position));
        TapPos = SwordTap.position;
        Debug.DrawLine(transform.position, transform.forward, Color.blue,1f);
    }

    void Ray(Vector3 Pos)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, 1023))
        {
            Debug.DrawLine(transform.position, transform.forward, Color.blue);
            if (OP == true)
            {
                IKHR.swordGoo(Pos, 1);
                StartCoroutine(AttackTime(1));
                OP = false;
                Debug.Log("fire0");
            }
        }
    }
    IEnumerator AttackTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);


        OP = true;

    }
}
