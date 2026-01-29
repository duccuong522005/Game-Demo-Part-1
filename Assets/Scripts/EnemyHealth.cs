using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision) => Die();

    private void Die()
    {
        if (explosionPrefab != null)
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
