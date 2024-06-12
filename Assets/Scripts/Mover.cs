using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    const string HorizontalAxis = "Horizontal";

    private bool _isGrounded = false;
    private bool _isJump = false;

    private void Update()
    {
        _isGrounded = _groundChecker.IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        Move();

        if(_isJump)
        {
            Jump();
            _isJump = false;
        }
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis(HorizontalAxis) * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = moveInput;
    }

    private void Jump()
    {
        _rigidbody.AddRelativeForce(Vector2.up * _jumpForce);
    }
}
