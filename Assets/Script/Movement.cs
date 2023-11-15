using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Component
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    //Variable
    [SerializeField] private float speed = 1f;
    
    //Singleton
    private InputManager inputManager;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        Running();
    }

    void Running()
    {
        Vector2 direction = inputManager.GetKeyboardInput().normalized;
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);

        if (direction.x < 0)
        {
            sr.flipX = true;
        }
        else if (direction.x > 0)
        {
            sr.flipX = false;
        }
    }
}
