using UnityEngine;

public class Aid : CollectableObject
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private int _treatmentEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.GetComponent<Health>().Heal(_treatmentEffect);
            StartCoroutine(Disappear());
        }
    }
}
