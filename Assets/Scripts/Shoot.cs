using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _bulletHolePrefab = new List<GameObject>();

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hitInfo;
            if(Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 8))
            {
                Instantiate(PickRandomBulletHole(), hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            Cursor.lockState = CursorLockMode.None;
    }

    private GameObject PickRandomBulletHole()
    {
        int rand = Random.Range(0, _bulletHolePrefab.Count);
        return _bulletHolePrefab[rand];
    }
}
