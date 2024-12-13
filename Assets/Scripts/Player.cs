using System;
using Input;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float castDistance;

    public void Start()
    {
        
    }

    public void Update()
    {
        HandleMovement();
        NormalizeRotation();
    }

    private void NormalizeRotation()
    {
        float rotationSpeed;
        if(transform.rotation.z != 0) 
        {
            rotationSpeed = Math.Abs(transform.rotation.z * 15f);
            Debug.Log(transform.rotation.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime*rotationSpeed);
        }
    }

    private void HandleMovement()
    {
        //Left and right movement
        float moveDir = GameInput.Instance.GetHorizontalMovementDirection();
        transform.position += new Vector3(moveDir * horizontalSpeed * Time.deltaTime,0,0);
        
        //Jump
        float jumpMagnitude = GameInput.Instance.GetJumpInputMagnitude();
        if(IsGrounded())
            rb.AddForce(new Vector2(0f, jumpMagnitude*jumpForce));
    }


    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, castDistance);
    }
}                        
