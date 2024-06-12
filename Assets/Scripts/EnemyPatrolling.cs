using System.Collections;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _eyes;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _speed = 1.6f;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private float _timeToAttack = 0.5f;

    private const string Attack = "Attack";

    private WaitForSeconds waitForSeconds;
    private Transform _player;
    private Transform _target;
    private float _attackDistance = 2f;
    private float _cooldownTimer;
    private int _index;
    private int _visibleDistance = 20;
    private int _flipAngle = 180;
    private int _defaultAngle = 0;
    private bool _isMovingRight = false;
    private bool _isMovingLeft = false;
    private bool _canAttack = false;

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(_timeToAttack);
        _cooldownTimer = _attackCooldown;
        transform.position = _points[_index].position;
        _index = 1;
        _target = _points[_index];
    }

    private void Update()
    {
        if (IsSeeingPlayer())
        {
            GoAttackPlayer();

            if(_canAttack == true && _cooldownTimer >= _attackCooldown)
            {
                _cooldownTimer = 0;
                StartCoroutine(AttackPlayer());
            }
        }
        else
        {
            Patrol();
        }

        _cooldownTimer += Time.deltaTime;
    }

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

    private IEnumerator AttackPlayer()
    {
        _animator.SetTrigger(Attack);

        yield return waitForSeconds;

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

        foreach (Collider2D hitObject in hitObjects)
        {
            if (hitObject.TryGetComponent(out Player player))
            {
                player.TakeDamage(50);
            }
        }

        _canAttack = false;

        yield return null;
    }


    private void GoAttackPlayer()
    {
        GoToTarget(_player);

        if (Vector2.Distance(transform.position, _player.position) < _attackDistance)
        {
            _canAttack = true;
        }
    }

    private bool IsSeeingPlayer()
    {
        RaycastHit2D hit;
        
        if (transform.rotation.y == -1)
        {
            hit = Physics2D.Raycast(_eyes.position, Vector2.left, _visibleDistance);
        }
        else
        {
            hit = Physics2D.Raycast(_eyes.position, Vector2.right, _visibleDistance);
        }

        if (hit.collider.gameObject.TryGetComponent(out Player player))
        {
            _player = player.transform;
            return true;
        }

        return false;
    }

    private void GoToTarget(Transform target)
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

    private void Patrol()
    {
        GoToTarget(_target);

        if (Vector2.Distance(transform.position, _target.position) < 1f)
        {
            _index++;

            if(_index >= _points.Length)
            {
                _index = 0;
            }

            _target = _points[_index];
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
