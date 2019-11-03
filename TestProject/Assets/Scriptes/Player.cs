using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidbody;
    private Vector3 movement;   

    private void FixedUpdate()
    {
        if (GameManager.Instance.isControllerSwitch)
            ThirdPersonController();
        else
            TopDownController();
    }

    private void ThirdPersonController()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor != 0 || ver != 0)
        {
            Vector3 movement = new Vector3(hor, 0, ver) * speed * Time.deltaTime;
            transform.Translate(movement, Space.Self);
            animator.SetFloat("Speed", 5);
        }
        else
            animator.SetFloat("Speed", 0);
    }

    private void TopDownController()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        if (movement.x != 0 || movement.z != 0)
        {
            rigidbody.MovePosition(rigidbody.position + movement * speed * Time.deltaTime);
            animator.SetFloat("Speed", 5);
        }
        else
            animator.SetFloat("Speed", 0);
    }
}
