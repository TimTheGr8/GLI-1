using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    
    private Vector3 _targetDesination;


    void Start()
    {
        _targetDesination = transform.position;
    }

    void Update()
    {
        if (transform.position != _targetDesination)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetDesination, _speed * Time.deltaTime);
        }
    }

    public void SetDestination(Vector3 destination)
    {
         _targetDesination = destination;
        _targetDesination.y = 1;
    }
}
