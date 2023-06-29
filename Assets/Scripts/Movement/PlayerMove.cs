using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace HEXRPG.Movement
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Camera _cam;
        private NavMeshAgent _agent;

        private CustomInput _customInput;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            _customInput = new CustomInput();
        }


        private void OnEnable()
        {
            _customInput.Enable();
            _customInput.PlayerActionMap.Movement.performed += OnMovementPerformed;
        }

        private void OnDisable()
        {
            _customInput.Disable();
            _customInput.PlayerActionMap.Movement.performed -= OnMovementPerformed;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }

            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }

        // движение персонажа если зажать лкм
        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                MoveTo(hit.point);
            }
        }

        private void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }

        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Vector2 mousePos = Mouse.current.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(mousePos);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    _agent.SetDestination(hit.point);
                }
            }
        }
    }
}