using UnityEngine;

public class Chasing : MonoBehaviour
{
    [SerializeField] private Transform _eyes;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Attacker _attacker;

    private Transform _player;
    private int _visibleDistance = 20;
    private float _attackDistance = 2f;

    public void GoToPlayer()
    {
        _mover.GoToTarget(_player);

        if (Vector2.Distance(transform.position, _player.position) < _attackDistance)
        {
            _attacker.SetAttackPossibility(true);
        }
    }

    public bool IsSeeingPlayer()
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
}
