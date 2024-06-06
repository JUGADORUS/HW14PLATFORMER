using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _pointOne;
    [SerializeField] private GameObject _pointTwo;
    [SerializeField] private float _speed;

    private Transform _target;

    private void Start()
    {
        transform.position = _pointOne.transform.position;
        _target = _pointTwo.transform;
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (_target == _pointTwo.transform)
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
        }

        if (Vector2.Distance(transform.position, _target.position) < 1f && _target == _pointOne.transform)
        {
            _target = _pointTwo.transform;
            Flip();
        }
        if (Vector2.Distance(transform.position, _target.position) < 1f && _target == _pointTwo.transform)
        {
            _target = _pointOne.transform;
            Flip();
        }
    }

    private void Flip()
    {
        gameObject.transform.Rotate(0, 180, 0);
    }
}
