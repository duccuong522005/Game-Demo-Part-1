using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [Header("Path Settings")]
    public Transform[] waypoints;
    public float moveSpeed = 5f;

    private int waypointIndex = 0;

    void Update()
    {
        MoveAlongPath();
    }

    private void MoveAlongPath()
    {
        if (waypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
            waypointIndex = 0;
        }
    }
}