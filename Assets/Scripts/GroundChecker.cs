using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _platformLayerMask;
    [SerializeField] private BoxCollider2D _boxCollider2D;

    public bool IsGrounded()
    {
        float inaccuracy = 0f;
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, inaccuracy, _platformLayerMask);

        return hit.collider != null;
    }
}
