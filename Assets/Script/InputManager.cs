using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 KeyboardInput {  get; private set; }
    public Vector2 MousePos { get; private set; }
    public float OnFire {  get; private set; }
    public bool OnSwitch {  get; private set; }
    public float ScrollWheel {  get; private set; }

    private void Update()
    {
        GetLeftMouseDown();
        GetRightMouseDown();
        GetMouseScroll();
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
        OnFire = Input.GetAxis("Fire1");
    }
    protected virtual void GetRightMouseDown()
    {
        OnSwitch = Input.GetMouseButtonDown(1);
    }

    protected virtual void GetMouseScroll()
    {
        ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
    }
}
