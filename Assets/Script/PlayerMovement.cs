using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private Vector2 inputDirection;

    public void Move(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        var position = (Vector2)transform.position;
        var targetPosition = position + inputDirection;
        rb.DOMove(targetPosition, moveSpeed).SetSpeedBased();
    }
}
