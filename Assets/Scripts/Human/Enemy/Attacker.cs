using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public bool CanAttack { get; private set; }

    private const string Attack = "Attack";

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timeToAttack = 0.5f;
    [SerializeField] private float _attackRange = 0.5f;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_timeToAttack);
    }

    public IEnumerator AttackPlayer()
    {
        _animator.SetTrigger(Attack);

        yield return _waitForSeconds;

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

        foreach (Collider2D hitObject in hitObjects)
        {
            if (hitObject.TryGetComponent(out Health playerHealth) && hitObject.TryGetComponent(out Player player))
            {
                playerHealth.TakeDamage(50);
            }
        }

        CanAttack = false;

        yield return null;
    }

    public void SetAttackPossibility(bool isPossible)
    {
        CanAttack = isPossible;
    }
}
