using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private Chasing _chasing;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Patrolling _patrolling;

    private float _cooldownTimer;

    private void Start()
    {
        _cooldownTimer = _attackCooldown;
    }

    private void Update()
    {
        if (_chasing.IsSeeingPlayer())
        {

            _chasing.GoToPlayer();

            if(_attacker.CanAttack == true && _cooldownTimer >= _attackCooldown)
            {
                _cooldownTimer = 0;
                StartCoroutine(_attacker.AttackPlayer());
            }
        }
        else
        {
            _patrolling.Patrol();
        }

        _cooldownTimer += Time.deltaTime;
    }
}
