using UnityEngine;
using System.Collections;

public class FireDE : MonoBehaviour
{
    public float LTime=0.5f;
    public float DEM=20;
    private Player player;
    int bout = 5;
    public int setbout = 5;
    public GameObject fire;
    public bool infire=false;
    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponent<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void De()
    {
        if (infire == false)
        {
            bout = setbout;
            StartCoroutine(checkRangeAttackTime(LTime));
            GameObject Effect = Instantiate(fire, transform.position, transform.rotation) as GameObject;
            Effect.transform.parent = transform;
            infire = true;
        }
    }

    IEnumerator checkRangeAttackTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

       
        if (bout <= 0)
        {
            infire = false;
        }
        else {
            player.energy -= DEM;
            bout--;
            StartCoroutine(checkRangeAttackTime(LTime));
        }
    }
}
