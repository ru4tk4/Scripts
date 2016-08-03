using UnityEngine;
using System.Collections;

namespace Boss
{
    public class MosterDoorOpen : MonoBehaviour
    {

        public Animator doorain;
        public GameObject[] Mosters;
        public GameObject[] D;
        public BasicBoss[] IdleMonters;
        public float Gotime;
        // Use this for initialization
        void Start()
        {
            StartCoroutine(GOTime(Gotime));
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        IEnumerator GOTime(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

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
                if (doorain)
                    doorain.SetBool("Open", true);


                foreach (BasicBoss Moster in IdleMonters)
                {
                    if (Moster)
                    {
                        Moster.monterGO();
                    }
                }
                foreach (GameObject Dn in D)
                {
                    if (Dn)
                    {
                        Destroy(Dn);
                    }
                }
            }

            StartCoroutine(GOTime(Gotime));
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

