using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;
    public float speed = 2f;

    void Update()
    {
        if (patrolPoints.Length == 0) return;
        
        float distance = Vector2.Distance(transform.position, patrolPoints[currentPointIndex].position);
        
        if (distance > 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
        else
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }
}