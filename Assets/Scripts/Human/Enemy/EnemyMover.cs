using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 1.6f;

    private int _flipAngle = 180;
    private int _defaultAngle = 0;
    private bool _isMovingRight = false;
    private bool _isMovingLeft = false;

    private void FixedUpdate()
    {
        if (_isMovingRight)
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }
        else if (_isMovingLeft)
        {
            _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
        }
    }

    private void FlipToRight()
    {
        transform.rotation = Quaternion.Euler(0, _defaultAngle, 0);
    }

    private void FlipToLeft()
    {
        transform.rotation = Quaternion.Euler(0, _flipAngle, 0);
    }

    public void GoToTarget(Transform target)
    {
        if (target.position.x - transform.position.x > 0)
        {
            _isMovingRight = true;
            _isMovingLeft = false;
            FlipToRight();
        }
        else
        {
            _isMovingLeft = true;
            _isMovingRight = false;
            FlipToLeft();
        }
    }
}
