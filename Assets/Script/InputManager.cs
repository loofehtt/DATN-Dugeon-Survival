using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 KeyboardInput {  get; private set; }
    public Vector2 MousePos { get; private set; }
    public float OnFiring {  get; private set; }

    private void Update()
    {
        GetLeftMouseDown();
    }

    private void FixedUpdate()
    {
        GetKeyboardInput();
        GetMousePos();
    }
    protected virtual void GetKeyboardInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        KeyboardInput = new Vector2(x, y);
    }

    protected virtual void GetMousePos()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetLeftMouseDown()
    {
        OnFiring = Input.GetAxis("Fire1");
    }
}
