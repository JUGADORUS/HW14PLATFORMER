using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _playerVisual;
    [SerializeField] private Rigidbody2D _rigidbody;

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

        if (_rigidbody.velocity.x > 2f || _rigidbody.velocity.x < -2f)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }
}
