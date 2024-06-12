using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _attackPoint;

    private const string Attacking = "Attacking";

    private float _attackRange = 0.5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        _animator.SetTrigger(Attacking);

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);
        
        foreach(Collider2D hitObject in hitObjects)
        {
            if(hitObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(50);
            }
        }
    }
}
