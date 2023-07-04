using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEXRPG.Core
{
    public class ActionManager : MonoBehaviour
    {
        private MonoBehaviour currentAction;
        
        public void StartAction(MonoBehaviour action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                Debug.Log("Cancelling" + currentAction);
            }
            currentAction = action;
        }
    }
}
