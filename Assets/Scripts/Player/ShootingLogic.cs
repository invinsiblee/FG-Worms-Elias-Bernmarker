using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLogic : MonoBehaviour
{
    [SerializeField] private LayerMask mouseCollider;
    [SerializeField] private MyInput myinput;
    [SerializeField] private Transform vfxMiss;
    [SerializeField] private Transform vfxHit;
    private Transform hitTransform = null;
    private Vector3 mouseWorldPosition = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Shoot();
        
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseCollider))
        {
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }
    }

    void Shoot()
    {
        if (myinput.shoot && myinput.aimDown && hitTransform != null)
        {
            if (hitTransform.CompareTag("Player") || hitTransform.CompareTag("Player2") || hitTransform.CompareTag("Player3") || hitTransform.CompareTag("Player4"))
            {
                Instantiate(vfxHit, mouseWorldPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(vfxMiss, mouseWorldPosition, Quaternion.identity);
            }
        }
    }
}
