using UnityEngine;
using System.Collections;
namespace Boss {
    public class MosterLooKAtGo : StateMachineBehaviour {
        
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            
        //}

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            
           /* if (animator.GetComponent<BasicBoss>())
            {
                if (animator.GetComponent<BasicBoss>().Go ==true) {
                    Vector3 here = animator.GetComponent<BasicBoss>().target.position;
                    animator.gameObject.transform.LookAt(new Vector3(here.x, animator.gameObject.transform.position.y, here.z));
                }
            }*/
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
       // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //
        //}
    }
}