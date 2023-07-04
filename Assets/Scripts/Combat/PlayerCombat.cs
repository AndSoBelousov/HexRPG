using System;
using HEXRPG.Core;
using UnityEngine;
using HEXRPG.Movement;

namespace HEXRPG.Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        [Tooltip("���������� �� ����� ����� ����� ������� � �����������")]
        [SerializeField] private float weaponRange = 2f;

        private Transform _enemyTarget; //���������
        private PlayerMove _playerMove; //��������� ����������� ������

        private void Awake()
        {
            _playerMove = GetComponent <PlayerMove> ();
        }

        private void Update() 
        {
            if (_enemyTarget == null) return; //����� �� ������ ��� ���������� ����������

            if (_enemyTarget != null && !GetIsInRange())
            {
                _playerMove.MoveTo(_enemyTarget.position); //�������� � ������� ����������
            } 
            else 
            {
                _playerMove.StopMove();
                GetComponent<Animator>().SetTrigger("Attack");
            }
        }
        
        //���������� ����� ������� � ����������� ��� �����
        private bool GetIsInRange() 
        {
            return Vector3.Distance(transform.position, _enemyTarget.position) < weaponRange;
        }

        //����� ���� ��� �����
        public void Attack(Target target) 
        {
            _enemyTarget = target.transform;
            GetComponent<ActionManager>().StartAction(this);
        }
        
        //����� ����
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