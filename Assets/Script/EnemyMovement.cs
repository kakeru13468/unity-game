using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private PlayerManager playerManager;
    private void FixedUpdate()
    {
        var playerPosition = playerManager.Position;
        var position = (Vector2)transform.position;
        var direction = playerPosition - position;
        direction.Normalize();
        var targetPosition = position + direction;
        rb.DOMove(targetPosition, moveSpeed).SetSpeedBased();
    }
}  
