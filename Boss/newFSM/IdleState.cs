using UnityEngine;
using System.Collections;

namespace NewFSM
{
    public class IdleState : MonoBehaviour, StateInterface
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