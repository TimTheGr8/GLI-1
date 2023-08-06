using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LayerMask : MonoBehaviour
{
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 6))
            {
                Renderer hitRenderer = hitInfo.collider.GetComponent<Renderer>();
                if (hitRenderer != null)
                    hitRenderer.material.color = Color.red;
            }
        }
    }
}
