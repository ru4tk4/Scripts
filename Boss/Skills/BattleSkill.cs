using UnityEngine;
using System.Collections;

namespace Boss
{
    public class BattleSkill : MonoBehaviour, SkillState
    {
        private MoveBehavior moveBehavior;
        private BasicBoss self;
        //private Vector3 playerhere;
        int MoveLR=0;
        int MoveF = 2;
        float RotaF = 0;
        float RotaR = 0;
        float RotaU = 0;
        float distance = 0;
        
        
        #region SkillState implementation

        public void enter(BasicBoss boss)
        {
            self = boss;
            moveBehavior = new MoveBehavior(boss, self.maxAttackVelocity, delegate { });
            moveBehavior.NMAenter();


            self.m_Ani.SetInteger("Move", MoveF);
            StartCoroutine(checkRangeAttackTime(Random.Range(self.RangeTimeMin, self.RangeTimeMax)));
            StartCoroutine(checkTime(1f));
            self.state = BasicBoss.BossState.Move;
        }


        public void execute()
        {
            
            moveBehavior.NMAexecute();
            
            Movedata();
            self.m_Ani.SetInteger("Move", MoveF);
            AttackMove();

            
        }

        public void exit()
        {

            moveBehavior.NMAexit();
            Destroy(this);
        }

        #endregion
        
        void Movedata()
        {

            distance = self.TargetData().w;
            RotaF = self.TargetData().x;
            RotaR = self.TargetData().y;
            RotaU = self.TargetData().z;

            if (distance > self.selfDistance.TraceDistance&& self.state != BasicBoss.BossState.Attack)
            {
                self.changeState(gameObject.AddComponent<TraceSkill>());
            }
        }
        
        void AttackMove()
        {

            
            float MoveXV = 0;
           
            if (RotaF > 90)
            {
                MoveF = 2;
                MoveXV = RotaR <= 90 ? -2 : 2 ;              
            }
            else
            if (RotaF > 10)
            {             
                MoveXV = RotaR <= 90 ? -1 : 1;
            }
            else
            {

                MoveXV = 0;
                if (distance < self.selfDistance.AttackDistance&&Time.time >self.atttime)
                {
                    self.atttime = Time.time + self.attCD;
                    
                    
                    self.changeState(gameObject.AddComponent<AttackSkill>());
                    
                }
               //調整攻擊時機 防止連續判定

            }

           
            self.m_Ani.SetFloat("MoveX", MoveXV, 0.25f, Time.deltaTime);

            self.m_Ani.SetFloat("MoveY", MoveLR, 0.25f, Time.deltaTime);
     
        }

       

        IEnumerator checkRangeAttackTime(float waitTime)
        {
            
            yield return new WaitForSeconds(waitTime);
            Debug.Log("RA");
            if (distance <= 9)
            {
                self.m_Ani.SetTrigger("RunAttack");
                
            }
            
            if (distance > self.selfDistance.RangeDistance.x && distance <= self.selfDistance.RangeDistance.y && self.isRange)
            {
                self.changeState(gameObject.AddComponent<AttackSkill>());
               
            }
            else {
                
            }
            StartCoroutine(checkRangeAttackTime(Random.Range(self.RangeTimeMin, self.RangeTimeMax)));
        }

        IEnumerator checkTime(float waitTime)
        {
            
            yield return new WaitForSeconds(waitTime);
            MoveF = MoveF>2? 2 : 3 ;
            MoveLR = Random.Range(0, 2);
            StartCoroutine(checkTime(Random.Range(1, 5)));
            
        }


      
    
        public void Fire()
        {
        }
        public void FireGun()
        {
            
            GameObject bulle = Instantiate(self.B_bullet, self.B_FireObj.transform.position, self.B_FireObj.transform.rotation) as GameObject;
            GameObject bulle1 = Instantiate(self.B_bulletFire, self.B_FireObj.transform.position, self.B_FireObj.transform.rotation) as GameObject;
            bulle.GetComponent<Rigidbody>().AddForce((self.B_FireObj.transform.forward + new Vector3(0, 0, 0)) * self.B_bulletSpeed);

        }
        public void Hold()
        {

        }
    }
}