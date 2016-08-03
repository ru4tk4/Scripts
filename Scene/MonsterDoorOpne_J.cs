using UnityEngine;
using System.Collections;

namespace Boss
{
    public class MonsterDoorOpne_J : MonoBehaviour
    {
        public Animator doorain;
        public GameObject[] Mosters;
        public Animator UI;

        void OnTriggerEnter()
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

        public void UIAni()
        {
            UI.SetTrigger("Open");
        }
    }
}
