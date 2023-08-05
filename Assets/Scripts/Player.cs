using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // User Input
    // Left Mouse click

    // Fire Raycast from main camera or mouse posisition
    // Access the object that was hit
    // Change color

    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(_ray.origin, _ray.direction * 1000, Color.green);
            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.collider != null)
                    _hit.collider.GetComponent<Renderer>().material.color = Random.ColorHSV();
            }
        }
    }
}
