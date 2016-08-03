using UnityEngine;
using System.Collections;
namespace NewFSM
{
    public class AttackState : MonoBehaviour,StateInterface
    {
        private MainSystem Main;
        public void StateEnter(MainSystem data)
        {
            Main = data;
        }
        public void StateUpdate()
        {

        }
        public void StateExit()
        {
            Destroy(this);
        }
    }
}
