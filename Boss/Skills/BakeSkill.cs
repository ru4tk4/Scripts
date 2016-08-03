using UnityEngine;
using System.Collections;

namespace Boss
{
    public class BakeSkill : MonoBehaviour, SkillState
    {
        private MoveBehavior moveBehavior;
        private BasicBoss self;
        float baketime;
        float BakeTime = 5f;
        
        
        #region SkillState implementation

        public void execute()
        {
            moveBehavior.NMAexecute();
            moveBehavior.waypoint = self.stpos;
            moveBehavior.turnToDirection(2f);
            moveBehavior.moveToPoint();
            if (Vector3.Distance(self.target.position, self.transform.position) < self.selfDistance.TraceMax)
            {
                Debug.Log("bake1");
                self.changeState(gameObject.AddComponent<TraceSkill>());
            }
            else 
            if(Vector3.Distance(self.stpos, self.transform.position)<0.1f)
            {
                self.changeState(gameObject.AddComponent<IdleSkill>());
                Debug.Log("bake2");
            }
                
           
            //			moveBehavior.checkOutOfVision();

        }

       
        public void enter(BasicBoss boss)
        {
            self = boss;
            moveBehavior = new MoveBehavior(boss, self.maxAttackVelocity, delegate { });
            moveBehavior.NMAenter();
            
            
            if (self.IFIK == true)
            {
                self.IKSwitch(false);
            }
            
            self.state = BasicBoss.BossState.Move;
        }

        public void exit()
        {

            moveBehavior.NMAexit();
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
