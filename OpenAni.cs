using UnityEngine;
using System.Collections;
namespace Boss
{
    public class OpenAni : MonoBehaviour
    {
        BasicBoss boss;
        public GameObject fire;
        public GameObject rf;
        public GameObject rf_s1;
        public GameObject rf_s2;
        public Animator[] mon; 
        
        float K;
        bool i = false;
        bool Ra = false;
        bool handd = false;
        // Use this for initialization
        void Start()
        {
            boss = GetComponent<BasicBoss>();
            K = boss.hp;
            InvokeRepeating("RA", 30, 30);
            InvokeRepeating("handdd", 1, 1);
            
        }

        // Update is called once per frame
        void Update()
        {



            if (boss.hp / K < 0.7||handd==true)
            {
                foreach (Animator a in mon)
                {
                    a.SetBool("HandGo",true);
                }

                if (boss.hp / K < 0.6)
                {
                    Ra = true;
                }

                if (boss.hp / K < 0.2&&i==false)

                {

                    rf.SetActive(true);

                    i = true;

                }
               
                
            }

        }

        public void handdd()
        {

            foreach (Animator a in mon)
            {
                if (a.enabled == false)
                {
                    handd = true;
                }
            }
        }

        public void RA()
        {
            
            if(Ra == true)
            {
                rf_s1.SetActive(true);
                rf_s2.SetActive(true);
            }

        }


        public void OP()
        {
            fire.SetActive(true);
        }
        public void ST()
        {
            fire.SetActive(false);
        }
    }
}
