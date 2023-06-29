using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;
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
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
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
