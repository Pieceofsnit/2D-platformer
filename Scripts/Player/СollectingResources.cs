using UnityEngine;

public class СollectingResources : MonoBehaviour
{
    [SerializeField] private Health _health;

    private int _appleCoinAmount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out LifePoint lifePoint))
        {
            _health.Restore(lifePoint.HealthBonus);
            lifePoint.Destroy();
        }
        if (collision.TryGetComponent(out AppleCoin appleCoin))
        {
            _appleCoinAmount++;
            appleCoin.Destroy();
        }
    }
}