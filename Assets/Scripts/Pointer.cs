using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pointer : MonoBehaviour
{
    private ClickToMove _movePlayer;

    private void Start()
    {
        _movePlayer = FindAnyObjectByType<ClickToMove>().GetComponent<ClickToMove>();
        if (_movePlayer == null)
            Debug.Log("There is no ClickToMove script");
    }

    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 9))
            {
                _movePlayer.SetDestination(hitInfo.point);
            }
        }
    }
}
