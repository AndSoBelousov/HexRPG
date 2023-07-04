using System;
using HEXRPG.Core;
using UnityEngine;
using HEXRPG.Movement;

namespace HEXRPG.Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        [Tooltip("Расстояние во время атаки между игроком и противником")]
        [SerializeField] private float weaponRange = 2f;

        private Transform _enemyTarget; //противник
        private PlayerMove _playerMove; //компонент перемещения игрока

        private void Awake()
        {
            _playerMove = GetComponent <PlayerMove> ();
        }

        private void Update() 
        {
            if (_enemyTarget == null) return; //выход из метода при отсутствии противника

            if (_enemyTarget != null && !GetIsInRange())
            {
                _playerMove.MoveTo(_enemyTarget.position); //движение в сторону противника
            } 
            else 
            {
                _playerMove.StopMove();
                GetComponent<Animator>().SetTrigger("Attack");
            }
        }
        
        //расстояние между игроком и противником при атаке
        private bool GetIsInRange() 
        {
            return Vector3.Distance(transform.position, _enemyTarget.position) < weaponRange;
        }

        //задаём цель для атаки
        public void Attack(Target target) 
        {
            _enemyTarget = target.transform;
            GetComponent<ActionManager>().StartAction(this);
        }
        
        //сброс цели
        public void CancelFight() 
        {
            _enemyTarget = null;
        }

        //AnimationEvent
        void Hit()
        {
            
        }
    }
}