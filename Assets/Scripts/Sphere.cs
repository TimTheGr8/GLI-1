using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
            Debug.Log("There is no Rigidbody");
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1f, Color.green);
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down,out hitInfo, 1f))
        {
            if(hitInfo.collider.name == "Floor")
            {
                _rb.useGravity = false;
                _rb.isKinematic = true;
            }
        }
    }
}
