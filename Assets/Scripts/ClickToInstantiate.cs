using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject _spherePrefab;

    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            var mousePos = Mouse.current.position.ReadValue();
            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                if(hitInfo.collider.tag == "Floor")
                {
                    Instantiate(_spherePrefab, hitInfo.point, Quaternion.identity);
                }
            }
        }
    }
}
