using UnityEngine;
using System.Collections;


namespace Boss {
public class MonsterDoorOpne_new : MonoBehaviour {

    public Animator doorain;
    public GameObject[] Mosters;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float KeyNumber = 0;
        foreach (GameObject Moster in Mosters)
        {
            if (Moster)
            {
                KeyNumber += Moster.GetComponent<BasicBoss>() ? 1 : 0;
            }


        }




        if (KeyNumber <= 0)
        {
            doorain.SetBool("Open", true);
        }

    }

    void OnTriggerEnter(Collider other1)
    {
        /*if (other1.tag == "Player")
        {
            float KeyNumber = 0;
            foreach (GameObject Moster in Mosters)
            {
                if (Moster)
                {
                    KeyNumber += Moster.GetComponent<BasicBoss>() ? 1 : 0;
                }


            }

            if (KeyNumber <= 0)
            {
                doorain.SetBool("Open", true);
            }

        }*/

    }

}
}
