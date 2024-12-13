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
        RecenterMass();
    }

    public void Update()
    {
        HandleMovement();
        NormalizeRotation();
    }

    private void RecenterMass()
    {
        rb.centerOfMass = new Vector2(0,0);
    }
    
    private void NormalizeRotation()
    {
        float zRotation = transform.rotation.eulerAngles.z;
        Debug.Log(zRotation);
        if (zRotation is >= 30 and <= 180)
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, Math.Clamp(zRotation, 0, 30f));
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 30f), 100f*Time.deltaTime);
        }
        else if (zRotation is <= 330 and >= 180)
        {
            // transform.rotation = Quaternion.Euler(0f, 0f, Math.Clamp(zRotation, 330, 360));
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 330f), 100f*Time.deltaTime);
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

    public Vector2 GetCenterOfMass()
    {
        return rb.worldCenterOfMass;
    }
}                        
