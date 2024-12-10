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
    }

    private void HandleMovement()
    {
        //Left and right movement
        float moveDir = GameInput.Instance.GetHorizontalMovementDirection();
        transform.position += new Vector3(moveDir * horizontalSpeed,0,0);
        
        //Jump
        float jumpMagnitude = GameInput.Instance.GetJumpInputMagnitude();
        Debug.Log(IsGrounded());
        if(IsGrounded())
            rb.AddForce(new Vector2(0f, jumpMagnitude*jumpForce));
    }


    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, castDistance);
    }
}                        
