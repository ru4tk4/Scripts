using UnityEngine;
using System.Collections;

namespace Boss
{
    public class aimSkill : MonoBehaviour, SkillState
    {
        private BasicBoss self;
        private SearchBehavior searchBehavior;
        private MoveBehavior moveBehavior;

        public void execute()
        {
            moveBehavior.waypoint = self.target.position;
            moveBehavior.turnToDirection(4f);
        }

        public void enter(BasicBoss boss)
        {

            StartCoroutine(checkRangeAttackTime(3));
        }

        IEnumerator checkRangeAttackTime(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            float distance = Vector3.Distance(self.target.position, self.transform.position);

            if (distance > 7 && self.isRange)
            {
                self.changeState(gameObject.AddComponent<AttackSkill>());
            }
            else
            {
                StartCoroutine(checkRangeAttackTime(2));
            }
        }

        public void exit()
        {
            Destroy(this);
        }

    }
}