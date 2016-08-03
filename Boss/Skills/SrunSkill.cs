using UnityEngine;
using System.Collections;

namespace Boss
{
    public class SrunSkill : MonoBehaviour, SkillState
    {
        private MoveBehavior moveBehavior;
        private BasicBoss self;

        #region SkillState implementation

        public void execute()
        {
            moveBehavior.waypoint = self.target.position;
            moveBehavior.turnToDirection(2f);
            moveBehavior.moveToPoint();
            if (self.Battle == true)
            {
                if (Vector3.Distance(self.target.position, gameObject.transform.position) <= self.selfDistance.BattleDistance)
                {
                    if (self.BigBattle == false)
                    {
                        self.changeState(gameObject.AddComponent<BattleSkill>());
                    }
                    else
                    {
                        self.changeState(gameObject.AddComponent<BigBattleSkill>());
                    }
                }
            }
            //			moveBehavior.checkOutOfVision();
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + (transform.forward * self.attackRange) + transform.right);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + transform.forward * self.attackRange);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + (transform.forward * self.attackRange) - transform.right);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + (transform.forward * -self.attackRange) + transform.right);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + transform.forward * -self.attackRange);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + (transform.forward * -self.attackRange) - transform.right);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + (transform.right * self.attackRange) + transform.right);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + transform.right * self.attackRange);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + (transform.right * self.attackRange) - transform.right);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + (transform.right * -self.attackRange) + transform.right);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + transform.right * -self.attackRange);
            Gizmos.DrawLine(transform.position + Vector3.up, transform.position + (transform.right * -self.attackRange) - transform.right);

        }

        IEnumerator checkRangeAttackTime(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            float distance = Vector3.Distance(self.target.position, self.transform.position);
            if (distance > self.selfDistance.RangeDistance.x && distance < self.selfDistance.RangeDistance.y && self.isRange)
            {
                self.changeState(gameObject.AddComponent<AttackSkill>());
            }
            else {
                StartCoroutine(checkRangeAttackTime(Random.Range(self.RangeTimeMin, self.RangeTimeMax)));
            }
        }



        public void enter(BasicBoss boss)
        {


            self = boss;
            if (self.IFIK == true)
            {
                self.IKSwitch(false);
            }

            moveBehavior = new MoveBehavior(boss, self.maxAttackVelocity, delegate {
                if (self.Battle == false)
                {
                    bool leftRay = Physics.Linecast(transform.position + Vector3.up, transform.position + (transform.forward * self.attackRange) - transform.right, self.playerLayer);
                    bool middleRay = Physics.Linecast(transform.position + Vector3.up, transform.position + transform.forward * self.attackRange, self.playerLayer);
                    bool rightRay = Physics.Linecast(transform.position + Vector3.up, transform.position + (transform.forward * self.attackRange) + transform.right, self.playerLayer);

                    bool leftRay1 = Physics.Linecast(transform.position + Vector3.up, transform.position + (transform.forward * -self.attackRange) - transform.right, self.playerLayer);
                    bool middleRay1 = Physics.Linecast(transform.position + Vector3.up, transform.position + transform.forward * -self.attackRange, self.playerLayer);
                    bool rightRay1 = Physics.Linecast(transform.position + Vector3.up, transform.position + (transform.forward * -self.attackRange) + transform.right, self.playerLayer);

                    bool leftRay2 = Physics.Linecast(transform.position + Vector3.up, transform.position + (transform.right * -self.attackRange) - transform.forward, self.playerLayer);
                    bool middleRay2 = Physics.Linecast(transform.position + Vector3.up, transform.position + transform.right * -self.attackRange, self.playerLayer);
                    bool rightRay2 = Physics.Linecast(transform.position + Vector3.up, transform.position + (transform.right * -self.attackRange) + transform.forward, self.playerLayer);

                    bool leftRay3 = Physics.Linecast(transform.position + Vector3.up, transform.position + (transform.right * self.attackRange) - transform.forward, self.playerLayer);
                    bool middleRay3 = Physics.Linecast(transform.position + Vector3.up, transform.position + transform.right * self.attackRange, self.playerLayer);
                    bool rightRay3 = Physics.Linecast(transform.position + Vector3.up, transform.position + (transform.right * self.attackRange) + transform.forward, self.playerLayer);
                    if (leftRay || middleRay || rightRay || leftRay2 || middleRay2 || rightRay2 || leftRay3 || middleRay3 || rightRay3)
                    {
                        self.changeState(gameObject.AddComponent<AttackSkill>());
                    }
                }
            });
            StartCoroutine(checkRangeAttackTime(Random.Range(self.RangeTimeMin, self.RangeTimeMax)));
            self.state = BasicBoss.BossState.Move;
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