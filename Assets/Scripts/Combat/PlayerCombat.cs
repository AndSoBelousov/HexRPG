using System;
using HEXRPG.Control;
using HEXRPG.Core;
using UnityEngine;
using HEXRPG.Movement;

namespace HEXRPG.Combat
{
    public class PlayerCombat : MonoBehaviour, IAction
    {
        [Tooltip("���������� �� ����� ����� ����� ������� � �����������")] 
        [SerializeField] private float _weaponRange = 2f;
        [SerializeField] private float _weaponDamage = 5f;
        [SerializeField] private float _timeBetweenAttacks = 1f;
        
        private HealthEnemy _enemyTarget; //���������
        private PlayerMove _playerMove; //��������� ����������� ������
        private float _timeSinceLastAttack = 0;

        private void Awake()
        {
            _playerMove = GetComponent<PlayerMove>();
        }

        private void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
            
            if (_enemyTarget == null) return; //����� �� ������ ��� ���������� ����������
            if (_enemyTarget.IsDead()) return;
            
            if (_enemyTarget != null && !GetIsInRange())
            {
                _playerMove.MoveTo(_enemyTarget.transform.position); //�������� � ������� ����������
            }
            else
            {
                _playerMove.Cancel();
                AttackManager();
            }
        }

        private void AttackManager()
        {
            if (_timeSinceLastAttack > _timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("Attack");//Trigger HitAnimationEvent()
                _timeSinceLastAttack = 0;
            }
        }
        
        //AnimationEvent
        void HitAnimationEvent()
        {
            _enemyTarget.TakeDamage(_weaponDamage);
        }
        
        //���������� ����� ������� � ����������� ��� �����
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, _enemyTarget.transform.position) < _weaponRange;
        }

        public bool CanAttack(Target target)
        {
            if (target == null)
            {
                return false;
            }
            HealthEnemy targetToTest = target.GetComponent<HealthEnemy>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        //����� ���� ��� �����
        public void Attack(Target target)
        {
            transform.LookAt(target.transform);
            _enemyTarget = target.GetComponent<HealthEnemy>();
            GetComponent<ActionManager>().StartAction(this);
        }

        //����� ����
        public void Cancel()
        {
            _enemyTarget = null;
            GetComponent<Animator>().SetTrigger("StopAttack");
        }


    }
}