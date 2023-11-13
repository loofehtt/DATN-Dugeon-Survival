using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Component
    private Rigidbody2D rb;

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
    }

    void Update()
    {
        //GetInput();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        rb.velocity = new Vector2(inputManager.GetInput().x * speed, inputManager.GetInput().y * speed);
    }
}
