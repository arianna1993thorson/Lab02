using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    Rigidbody rb;

    private float distanceToGround;
    bool isGrounded;
    public float jump = 5f;
    public float walkSpeed = 5f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    public Animator playerAnimator;
    private bool isWalking = false;

    private void Awake() {
        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();
    }

    private void OnEnable() 
    {
        move = walkSpeed * move;
    }

    private void Update() 
    {
        move = walkSpeed * move;
    }

    private void OnDisable() 
    {
        move = Vector2.zero;
    }

    private void Jump()
    {
        if (isGrounded == true)
        {
            jump = jump + distanceToGround;
        } 
        if (isGrounded == false) 
        {
            jump = distanceToGround - jump;
        }
    }
}
