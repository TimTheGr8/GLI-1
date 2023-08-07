using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AI : MonoBehaviour
{
    private enum AIState
    {
        Walking,
        Attacking,
        Jumping,
        Death
    }

    [SerializeField]
    private List<Transform> _waypoints = new List<Transform>();
    [SerializeField]
    private AIState _currentState;

    private NavMeshAgent _agent;
    private int _currentIndex = 0;
    private bool _increaseIndex = true;
    private bool _attacking = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
            Debug.Log("There is no Nav Mesh Agent");

        _agent.SetDestination(_waypoints[_currentIndex].position);
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _currentState = AIState.Jumping;
            _agent.isStopped = true;
        }
        switch (_currentState)
        {
            case AIState.Walking:
                CalculateMovement();
                break;
            case AIState.Attacking:
                if (!_attacking)
                {
                    StartCoroutine(AttackDelay());
                    _attacking = true;
                }
                Debug.Log("Attacking");
                break;
            case AIState.Jumping:
                Debug.Log("I am Jumping");
                break;
            case AIState.Death:
                break;
        }
    }

    private void CalculateMovement()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            if (_increaseIndex)
                IncreaseWaypoint();
            else
                DecreaseWaypoint();

            _agent.SetDestination(_waypoints[_currentIndex].position);
            _currentState = AIState.Attacking;
        }
    }

    private void IncreaseWaypoint()
    {
        if (_currentIndex == _waypoints.Count - 1)
        {
            _increaseIndex = false;
            _currentIndex--;
        }
        else
            _currentIndex++;
    }

    private void DecreaseWaypoint()
    {
        if(_currentIndex == 0)
        {
            _increaseIndex = true;
            _currentIndex++;
        }
        else
            _currentIndex--;
    }

    IEnumerator AttackDelay()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(1.0f);
        _currentState = AIState.Walking;
        _agent.isStopped = false;
        _attacking = false;
    }
}