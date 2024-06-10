using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        _isGrounded = _groundChecker.IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = moveInput;
    }

    private void Jump()
    {
        _rigidbody.AddRelativeForce(Vector2.up * _jumpForce);
    }
}
