using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _playerVisual;
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _runSpeed = 2f;

    private void FixedUpdate()
    {
        AnimateRunning();
    }

    private void AnimateRunning()
    {
        if (_rigidbody.velocity.x > 0)
        {
            _playerVisual.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (_rigidbody.velocity.x < 0)
        {
            _playerVisual.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (_rigidbody.velocity.x > _runSpeed || _rigidbody.velocity.x < -_runSpeed)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }
}
