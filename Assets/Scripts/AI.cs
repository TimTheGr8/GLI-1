using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _waypoints = new List<Transform>();

    private Transform _destination;
    private NavMeshAgent _agent;
    private bool _isAtTarget = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
            Debug.Log("There is no Nav Mesh Agent");

        _destination = _waypoints[0];
        _agent.destination = _destination.position;
    }

    void Update()
    {
        if(Vector3.Distance(_agent.destination, transform.position) < 1f)
        {
            _destination = _waypoints[RandomWaypoint()];
            _agent.destination = _destination.position;
        }
    }

    private int RandomWaypoint()
    {
        int randInt = Random.Range(0, _waypoints.Count);

        return randInt;
    }
}
