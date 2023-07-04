using HEXRPG.Combat;
using HEXRPG.Movement;
using UnityEngine;

namespace HEXRPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            if(CheckCombatInteraction()) return;
            if(CheckMovementInteraction()) return;
        }

        private bool CheckCombatInteraction()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            
            foreach (RaycastHit hit in hits)
            {
                Target target = hit.transform.GetComponent<Target>();

                if (!GetComponent<PlayerCombat>().CanAttack(target))
                {
                    continue;
                }
                
                if (Input.GetMouseButtonDown(0))//атака на лкм
                {
                    GetComponent<PlayerCombat>().Attack(target);
                }
                return true; //прерываем цикл если найден наш таргет
            }
            return false; //false если не найден таргет для взаимодействия и ищем дальше)
        }

        private bool CheckMovementInteraction()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<PlayerMove>().StartMoveTo(hit.point);
                }
                return true; //если было взаимодействие с перемещением
            }
            return false; //если не было взаимодействия с перемещением
        }
        
        //получаем луч по текущему положению мыши
        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}