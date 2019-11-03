using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform target;
    [SerializeField] private Transform player;
    [SerializeField] private float mouseYMin;
    [SerializeField] private float mouseYMax;
    private float mouseX, mouseY;

    private void LateUpdate()
    {
        if (GameManager.Instance.isControllerSwitch)
            ThirdPersonCamera();
        else
            TopDownCamera();
    }

    private void ThirdPersonCamera()
    {        
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, mouseYMin, mouseYMax);

        transform.LookAt(target);
        target.position = new Vector3(player.position.x, player.position.y + 2, player.position.z);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    private void TopDownCamera()
    {
        transform.LookAt(target);
        target.position = new Vector3(player.position.x, player.position.y + 5, player.position.z);
        target.rotation = Quaternion.Euler(75, 0, 0);
    }
}
