using UnityEngine;

public class LifePoint : MonoBehaviour
{
    private float _healthBonus = 1;
    public float HealthBonus => _healthBonus;

    public void Destroy()
    {
        Destroy(gameObject);
    }
}