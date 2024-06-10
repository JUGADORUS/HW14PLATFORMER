using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private Transform _target;
    private int _index;
    private int _flipAngle = 180;
    private int _defaultAngle = 0;
    private bool _isMovingRight = false;
    private bool _isMovingLeft = false;

    private void Start()
    {
        transform.position = _points[_index].position;
        _index = 1;
        _target = _points[_index];
    }

    private void Update()
    {
        Patrol();
    }

    private void FixedUpdate()
    {
        if (_isMovingRight)
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }
        else if(_isMovingLeft)
        {
            _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
        }
    }

    private void Patrol()
    {
        if (_target.position.x - transform.position.x > 0)
        {
            _isMovingRight = true;
            _isMovingLeft = false;
        }
        else
        {
            _isMovingLeft = true;
            _isMovingRight = false;
        }

        if (Vector2.Distance(transform.position, _target.position) < 1f)
        {
            _index++;

            if(_index >= _points.Length)
            {
                _index = 0;
            }

            _target = _points[_index];

            if (_target.position.x - transform.position.x > 0)
            {
                FlipToRight();
            }
            else
            {
                FlipToLeft();
            }
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
}
