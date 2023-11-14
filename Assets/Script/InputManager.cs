using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 GetKeyboardInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return new Vector2(x, y);
    }

    public Vector3 GetMousePos()
    {
        /*Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;*/
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
