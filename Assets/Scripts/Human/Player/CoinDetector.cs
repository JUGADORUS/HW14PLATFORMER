using UnityEngine;

public class CoinDetector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.TakeCoin();
            StartCoroutine(coin.Disappear());
        }
    }
}
