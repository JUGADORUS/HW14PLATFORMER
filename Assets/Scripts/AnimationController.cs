using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _playerVisual;
    [SerializeField] private Rigidbody2D _rigidbody;

    private const string IsRunning = "IsRunning";
    private float _runSpeed = 2f;

    private void FixedUpdate()
    {
        AnimateRunning();
    }

    private void AnimateRunning()
    {
        if (_rigidbody.velocity.x > 0)
        {
            _playerVisual.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (_rigidbody.velocity.x < 0)
        {
            _playerVisual.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (_rigidbody.velocity.x > _runSpeed || _rigidbody.velocity.x < -_runSpeed)
        {
            _animator.SetBool(IsRunning, true);
        }
        else
        {
            _animator.SetBool(IsRunning, false);
        }
    }
}
