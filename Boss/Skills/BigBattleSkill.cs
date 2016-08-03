using UnityEngine;
using System.Collections;

namespace Boss
{
    public class BigBattleSkill : MonoBehaviour, SkillState
    {
        private MoveBehavior moveBehavior;
        private BasicBoss self;
        private Vector3 playerhere;
        int MoveLR=0;
        int MoveF = 2;
        float Rota = 0;
        float distance = 0;
        #region SkillState implementation

        public void enter(BasicBoss boss)
        {


            self = boss;
 
            self.m_Ani.SetInteger("Move", MoveF);
            StartCoroutine(checkRangeAttackTime(Random.Range(self.RangeTimeMin, self.RangeTimeMax)));
            StartCoroutine(checkTime(1f));
            self.state = BasicBoss.BossState.Move;
        }


        public void execute()
        {
            Movedata();
            //AttackMove();
            
        }


        void Movedata()
        {
            

            Debug.DrawRay(gameObject.transform.position, playerhere, Color.green);

            distance = Vector3.Distance(self.target.position, self.transform.position);
            
            playerhere = self.target.position - gameObject.transform.position;

            Rota = Vector3.Angle(transform.forward, playerhere);

            self.m_Ani.SetInteger("Move", MoveF);


           
        }

        void AttackMove()
        {

            
            float MoveXV = 0;
           
            if (Rota > 90)
            {
                MoveF = 2;
                MoveXV = Vector3.Angle(transform.right, playerhere) <= 90 ? -2 : 2 ;
                
            }
            else
            if (Rota > 10)
            {
                
                MoveXV = Vector3.Angle(transform.right, playerhere) <= 90 ? -1 : 1;
            }
            else
            {

                MoveXV = 0;
                
               //調整攻擊時機 防止連續判定

            }

           
            self.m_Ani.SetFloat("MoveX", MoveXV, 0.25f, Time.deltaTime);

            self.m_Ani.SetFloat("MoveY", MoveLR, 0.25f, Time.deltaTime);
           /* if (MoveF == 3)
            {
                gameObject.transform.LookAt(self.target);
            }
            
    */
            
            
        }

       

        IEnumerator checkRangeAttackTime(float waitTime)
        {
            
            yield return new WaitForSeconds(waitTime);
            Debug.Log("RA");
            
            if (distance > self.selfDistance.RangeDistance.x && distance <= self.selfDistance.RangeDistance.y && self.isRange)
            {
                self.changeState(gameObject.AddComponent<AttackSkill>());
               
            }else
            if (distance < self.selfDistance.AttackDistance)
            {
                self.changeState(gameObject.AddComponent<AttackSkill>());
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


      
        public void exit()
        {
            Destroy(this);
        }

        #endregion
        public void Fire()
        {
        }
        public void FireGun()
        {

        }
        public void Hold()
        {

        }
    }
}