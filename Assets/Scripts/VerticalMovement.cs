using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _platformLayerMask;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;

    private void Update()
    {
        _isGrounded = CheckGround();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private bool CheckGround()
    {
        float inaccuracy = 0f; 
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down,inaccuracy, _platformLayerMask);

        return hit.collider != null;
    }

    private void Jump()
    {
        _rigidbody.AddRelativeForce(Vector2.up * _jumpForce);
    }
}
