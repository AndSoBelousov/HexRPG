using System;
using HEXRPG.Combat;
using HEXRPG.Movement;
using UnityEngine;

namespace HEXRPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            CombatInteraction();
            MovementInteraction();
        }

        private void CombatInteraction()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                Target target = hit.rigidbody.GetComponent<Target>();
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<PlayerCombat>().Attack(target);
                }
            }
        }

        private void MovementInteraction()
        {
            
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}