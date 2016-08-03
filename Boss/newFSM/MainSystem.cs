using UnityEngine;
using System.Collections;
namespace NewFSM
{
   
    public class MainSystem : MonoBehaviour
    {
       
        public StateInterface currentState;
        public Transform target;//攻擊目標
        // Use this for initialization

        void Start()
        {
            currentState = gameObject.AddComponent<IdleState>();
            currentState.StateEnter(this);
            StartCoroutine(LookTime(1));//5秒判斷一次距離
        }

        // Update is called once per frame
        void Update()
        {
            currentState.StateUpdate();//執行狀態的Update
            
        }


        //狀態更換
        public void changeState(StateInterface newState)
        {
            currentState.StateExit();//執行離開
            currentState = newState;
            newState.StateEnter(this);//執行進入
        }

     

        IEnumerator LookTime(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            targetDistance();
            StartCoroutine(LookTime(1));
        }
        //距離判斷
        public void targetDistance()
        {
            float D = Vector3.Distance(transform.position, target.position);
            if (D > 10)
            {
                Debug.Log("Idle");
                changeState(gameObject.AddComponent<IdleState>());
            }
            else if (D > 5)
            {
                Debug.Log("Move");
                changeState(gameObject.AddComponent<MoveState>());
            }
            else
            {
                Debug.Log("Attack");
                changeState(gameObject.AddComponent<AttackState>());
            }

        }



    }
}
