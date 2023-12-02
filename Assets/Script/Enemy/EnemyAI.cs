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

    //A* pathfinding
    Path path;
    Seeker seeker;
    int currentWaypoint;
    bool reachEndOfPath = false;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void FixedUpdate()
    {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;
        }

        else
        {
            reachEndOfPath = false;

        }

        Vector2 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        transform.position = Vector2.MoveTowards(transform.position, path.vectorPath[currentWaypoint], speed *Time.deltaTime);

        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
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
