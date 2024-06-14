using UnityEngine;

public class CollectableObjectDetector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.TakeCoin();
            StartCoroutine(coin.Disappear());
        }

        if (collision.TryGetComponent(out Aid aid))
        {
            _playerHealth.Heal(aid.treatmentEffect);
            StartCoroutine(aid.Disappear());
        }
    }
}
