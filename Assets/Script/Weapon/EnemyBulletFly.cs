using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFly : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Vector2 dir;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (dir != Vector2.zero)
        {
            rb.velocity = dir * speed;

        }

    }
}
