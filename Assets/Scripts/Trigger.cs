using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.TakeCoin();
            StartCoroutine(coin.Disappear());
        }
    }
}
