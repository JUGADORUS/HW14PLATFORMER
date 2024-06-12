using UnityEngine;

public class CollectableObjectDetector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.TakeCoin();
            StartCoroutine(coin.Disappear());
        }

        if (collision.TryGetComponent(out Aid aid))
        {
            _player.Heal();
            StartCoroutine(aid.Disappear());
        }
    }
}
