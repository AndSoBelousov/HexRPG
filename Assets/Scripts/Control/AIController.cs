using HEXRPG.Combat;
using HEXRPG.Core;
using HEXRPG.Movement;
using UnityEngine;

namespace HEXRPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float _chaseDistance = 15f;
        [SerializeField] private PatrolPath _patrolPath;
        [SerializeField] private float _waypointTolerance = 1f;
        
        private PlayerMove _playerMove;
        private Health _health;
        private PlayerCombat _playerCombat;
        private GameObject _player;
        private Vector3 _guardPosition;
        private int _currentWayPointIndex = 0;
        
        private void Start()
        {
            _playerMove = GetComponent<PlayerMove>(); //компонент движения
            _playerCombat = GetComponent<PlayerCombat>(); //компонент боя
            _player = GameObject.FindWithTag("Player"); //игрок
            _health = GetComponent<Health>(); //компонент здоровья
            _guardPosition = transform.position; //позиция врага
        }

        private void Update()
        {
            if (_health.IsDead()) return;
            if (InAttackRangeOfPlayer() && _playerCombat.CanAttack(_player))
            {
                _playerCombat.Attack(_player);
            }
            else
            {
                PatrolManager();//возврат врага на стартовую позицию
            }
        }

        private void PatrolManager()
        {
            Vector3 nextPosition = _guardPosition;
            if (_patrolPath != null)
            {
                if (AtWaypoint())
                {
                    CycleWaypoint();
                }
                nextPosition = GetCurrentWaypoint();
            }
            _playerMove.StartMoveTo(nextPosition);
        }

        private void CycleWaypoint()
        { 
            _currentWayPointIndex = _patrolPath.GetNextIndex(_currentWayPointIndex);
        }

        private bool AtWaypoint()
        {
            
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < _waypointTolerance;
        }

        private Vector3 GetCurrentWaypoint()
        {
            return _patrolPath.GetWaypoint(_currentWayPointIndex);
        }
        
        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
            return distanceToPlayer < _chaseDistance;
        }
    }
}