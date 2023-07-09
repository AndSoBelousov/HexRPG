using HEXRPG.Core;
using UnityEngine;
using HEXRPG.Movement;

namespace HEXRPG.Combat
{
    public class PlayerCombat : MonoBehaviour, IAction
    {
        [Tooltip("Расстояние во время атаки между игроком и противником")] 
        [SerializeField] private float _weaponRange = 2f;
        [SerializeField] private float _weaponDamage = 5f;
        [SerializeField] private float _timeBetweenAttacks = 1f;
        
        private Health _enemyTarget; //противник
        private PlayerMove _playerMove; //компонент перемещения игрока
        private float _timeSinceLastAttack = Mathf.Infinity;

        private void Awake()
        {
            _playerMove = GetComponent<PlayerMove>();
        }

        private void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
            
            if (_enemyTarget == null) return; //выход из метода при отсутствии противника
            if (_enemyTarget.IsDead()) return;
            
            if (!GetIsInRange())
            {
                _playerMove.MoveTo(_enemyTarget.transform.position); //движение в сторону противника
            }
            else
            {
                _playerMove.Cancel();
                AttackManager();
            }
        }

        private void AttackManager()
        {
            transform.LookAt(_enemyTarget.transform);
            if (_timeSinceLastAttack > _timeBetweenAttacks)
            {
                _timeSinceLastAttack = 0;
                TriggerAttack();
            }
        }

        //HitAnimationEvent trigger
        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("StopAttack");
            GetComponent<Animator>().SetTrigger("Attack");
        }

        //AnimationEvent
        void HitAnimationEvent()
        {
            if (_enemyTarget == null) return;
            _enemyTarget.TakeDamage(_weaponDamage);
        }
        
        //расстояние между игроком и противником при атаке
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, _enemyTarget.transform.position) < _weaponRange;
        }

        public bool CanAttack(GameObject target)
        {
            if (target == null)
            {
                return false;
            }
            Health targetToTest = target.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        //задаём цель для атаки
        public void Attack(GameObject target)
        {
            _enemyTarget = target.GetComponent<Health>();
            GetComponent<ActionManager>().StartAction(this);
        }

        //сброс цели
        public void Cancel()
        {
            StopAttack();
            _enemyTarget = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("Attack");
            GetComponent<Animator>().SetTrigger("StopAttack");
        }
    }
}