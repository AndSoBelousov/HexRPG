using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEXRPG.Core
{
    public class ActionManager : MonoBehaviour
    {
        private IAction currentAction;
        
        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
        }

        public void CancelCurrentAction()
        {
            StartAction(null);
        }
    }
}
