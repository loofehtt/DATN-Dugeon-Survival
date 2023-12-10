using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    float attackRange = 2f;

    //A* pathfinding
    Path path;
    Seeker seeker;
    int currentWaypoint;
    //bool reachEndOfPath = false;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }


    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        float reached = Vector2.Distance(transform.position, target.position);

        if (reached <= attackRange) return;

        if (path == null) return;

        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (currentWaypoint >= path.vectorPath.Count) return;

        transform.position = Vector2.MoveTowards(transform.position, path.vectorPath[currentWaypoint], speed * Time.deltaTime);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }


}
