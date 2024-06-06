using UnityEditor.Animations;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _playerVisual;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = moveInput;
    }
}
