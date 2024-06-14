using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private EnemyMover _mover;

    private Transform _target;
    private int _index;

    private void Start()
    {
        transform.position = _points[_index].position;
        _index = 1;
        _target = _points[_index];
    }

    public void Patrol()
    {
        _mover.GoToTarget(_target);

        if (Vector2.Distance(transform.position, _target.position) < 1f)
        {
            _index++;

            if (_index >= _points.Length)
            {
                _index = 0;
            }

            _target = _points[_index];
        }
    }
}
