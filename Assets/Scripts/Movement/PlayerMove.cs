using HEXRPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace HEXRPG.Movement
{
    public class PlayerMove : MonoBehaviour, IAction
    {
        private NavMeshAgent _agent;
        private Health _health;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _health = GetComponent<Health>();
        }
        
        private void Update()
        {
            UpdateAnimator();
            _agent.enabled = !_health.IsDead();
        }

        public void StartMoveTo(Vector3 destination)
        {
            MoveTo(destination); //перемещение к заданной точке
            GetComponent<ActionManager>().StartAction(this);
        }
        
        public void MoveTo(Vector3 destination)
        {
            _agent.destination = destination;
            _agent.isStopped = false;
        }
        
        public void Cancel()
        {
            _agent.isStopped = true;
        }
        
        private void UpdateAnimator()
        {
            Vector3 velocity = _agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }
    }
}