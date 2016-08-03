using UnityEngine;
using System.Collections;


namespace Boss
{
    public class MonsterDieCollider : MonoBehaviour
    {
        public GameObject TeachUI;
        public GameObject[] Monsters;
        public GameObject HealBox;
        public GameObject Player;
        public GameObject MainCam;
        private NewerUI NewerUI;
        public bool on_off = false;
        public float time;
        public float count;
        public bool T_F = false;


        void Start()
        {
            NewerUI = GameObject.Find("Newer_UI").GetComponent<NewerUI>();
        }

        void Update()
        {

            float num = 0;
            foreach (GameObject Monster in Monsters)
            {
                if (Monster)
                {
                    num += Monster.GetComponent<BasicBoss>() ? 1 : 0;
                }
            }


            if (num <= 0)
            {
                on_off = true;
            }


            if (on_off == true)
            {
                count += 1 * Time.deltaTime;
            }


            /*if (count >= time)
            {
                NewerUI.Ani_albert.speed = 0f;
                Player.GetComponent<Player>().enabled = false;
                Player.GetComponent<PlayerMove>().enabled = false;
                Player.GetComponent<GunFire>().enabled = false;
                Player.GetComponent<Input_Handler>().enabled = false;
                MainCam.GetComponent<MouseRotation>().enabled = false;
                TeachUI.SetActive(true);
                //HealBox.GetComponent<TextCollider>().enabled = true;
                T_F = true;
            }*/

            if (on_off == true)
            {
                //NewerUI.Ani_albert.speed = 1f;
                //Player.GetComponent<Player>().enabled = true;
                //Player.GetComponent<PlayerMove>().enabled = true;
                //Player.GetComponent<GunFire>().enabled = true;
                //Player.GetComponent<Input_Handler>().enabled = true;
                //MainCam.GetComponent<MouseRotation>().enabled = true;
                HealBox.GetComponent<BigHeal>().enabled = true;
                TeachUI.SetActive(true);
                TeachUI.GetComponent<Animator>().SetTrigger("Open");
                Destroy(gameObject);
            }
        }
    }
}
