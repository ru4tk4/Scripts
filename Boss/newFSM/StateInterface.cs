using UnityEngine;
using System.Collections;

namespace NewFSM
{
    public interface StateInterface
    {
        void StateEnter(MainSystem boss);
        void StateUpdate();        
        void StateExit();
    }
}
