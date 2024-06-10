using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _pointOne;
    [SerializeField] private Transform _pointTwo;
    [SerializeField] private float _speed;

    private Transform _target;

    private void Start()
    {
        transform.position = _pointOne.position;
        _target = _pointTwo;
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (_target == _pointTwo)
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
        }

        if (Vector2.Distance(transform.position, _target.position) < 1f && _target == _pointOne)
        {
            _target = _pointTwo;
            Flip();
        }
        if (Vector2.Distance(transform.position, _target.position) < 1f && _target == _pointTwo)
        {
            _target = _pointOne;
            Flip();
        }
    }

    private void Flip()
    {
        gameObject.transform.Rotate(0, 180, 0);
    }
}
