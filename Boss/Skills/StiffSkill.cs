using UnityEngine;
using System.Collections;

namespace Boss
{
    public class StiffSkill : MonoBehaviour, SkillState
    {
        private BasicBoss self;
        int stunTime = 3;
        public void execute()
        {
           
        }

        public void enter(BasicBoss boss)
        {
            
            //self = boss;
            
            //self.m_Ani.SetTrigger("Stiff");
            //StartCoroutine(checkTime1(1));
            
            
        }

        /*IEnumerator checkTime1(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            self.changeState(gameObject.AddComponent<TraceSkill>());
            
            
        }*/

        /*IEnumerator stiffTime(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);           
            self.stiffV += 3;
            Debug.Log("KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");

        }*/


        /*   IEnumerator resumeFromNegativeState(float waitTime)
           {
               yield return new WaitForSeconds(waitTime);
               Debug.Log("isBlock");
               self.m_Ani.SetBool("Block", false);
               self.changeState(gameObject.AddComponent<TraceSkill>());
           }*/

        public void exit()
        {
            Destroy(this);
            
        }

        public void Resume()
        {
            //Debug.Log("Hold");
            //self.changeState(gameObject.AddComponent<TraceSkill>());
        }

        public void Fire()
        {
        }

        public void FireGun()
        {

        }
        public void GunAim()
        {

            
        }

        public void Range()
        {

        }

        public void Jump()
        {

        }


        public void Land()
        {

        }

        public void Hold()
        {
            Debug.Log("Hold");
            //self.changeState(gameObject.AddComponent<TraceSkill>());
        }

    }
}