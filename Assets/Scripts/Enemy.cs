using System;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrol : MonoBehaviour
{
    [CanBeNull] public Transform[] patrolPoints;
    private int currentPointIndex = 0;
    public float speed = 1f;
    private Animator animator;
    private GameObject PatrolPoints;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PatrolPoints = GameObject.Find("PatrolPoints");
    }

    private void Start()
    {
        {
            Transform patrolPointsParent = PatrolPoints.transform;
                    patrolPoints = new Transform[patrolPointsParent.childCount];
                    for (int i = 0; i < patrolPointsParent.childCount; i++)
                    {
                        patrolPoints[i] = patrolPointsParent.GetChild(i);
                    }
        }
    }

    void Update()
    {
        animator.SetBool("Walking", true);
        
        if (patrolPoints.Length == 0) return;

        Vector2 currentPosition = rb.position;
        Vector2 targetPosition = patrolPoints[currentPointIndex].position;

        // Direction towards the next patrol point
        Vector2 direction = (targetPosition - currentPosition);

        // Set velocity
        rb.linearVelocity = direction * speed;

        // Check if close enough to switch to next point
        float distance = Vector2.Distance(currentPosition, targetPosition);
        if (distance < 0.05f)
        {
            if (currentPointIndex == patrolPoints.Length - 1)
            {
                currentPointIndex = 0;
                return;
            }
            currentPointIndex++;
        }
    }
}