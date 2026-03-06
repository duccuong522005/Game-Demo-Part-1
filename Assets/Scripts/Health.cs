using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint;
    public System.Action onDead;
    private int healthPoint;

    public int CurrentHealth => healthPoint;
    public bool IsDead => healthPoint <= 0;

    private void Awake()
    {
        healthPoint = Mathf.Max(0, defaultHealthPoint);
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;
        if (damage <= 0) return;

        healthPoint -= damage;
        if (healthPoint <= 0) Die();
    }

    public void Heal(int amount)
    {
        if (healthPoint <= 0) return;
        if (amount <= 0) return;

        healthPoint += amount;
    }

    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(explosion, 1f);
        }

        onDead?.Invoke();
        Destroy(gameObject);
    }
}