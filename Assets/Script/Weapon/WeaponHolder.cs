using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    //variable
    private Vector2 PointerPos;
    private Vector2 direction;

    private void FixedUpdate()
    {
        RotateWp();
        FlipWp();

    }

    private void FlipWp()
    {
        //Flip weapon
        Vector2 scale = transform.localScale;

        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else
        {
            scale.y = 1;
        }
        transform.localScale = scale;
    }

    private void RotateWp()
    {
        //Rotate Weapon
        PointerPos = InputManager.Instance.MousePos;

        direction = (PointerPos - (Vector2)transform.position).normalized;
        transform.right = direction;
    }
}
