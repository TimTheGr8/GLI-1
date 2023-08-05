using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Ray _rayOrigin;
    private RaycastHit _hitInfo;

    private void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            _rayOrigin = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(_rayOrigin, out _hitInfo))
            {
                var hitObjectRenderer = _hitInfo.collider.GetComponent<Renderer>();
                if (hitObjectRenderer != null)
                    if (_hitInfo.collider.tag == "Random Color")
                        hitObjectRenderer.material.color = Random.ColorHSV();
                    else if (_hitInfo.collider.tag == "Black")
                        hitObjectRenderer.material.color = Color.black;
            }
        }
    }
}
