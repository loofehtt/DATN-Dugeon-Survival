using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    //component
    [SerializeField] private SpriteRenderer characterSR;
    [SerializeField] private SpriteRenderer weaponSR;

    //variable
    private Vector2 PointerPos;

    //Singleton
    private InputManager inputManager;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void FixedUpdate()
    {
        //Rotate Weapon
        PointerPos = inputManager.GetMousePos();

        Vector2 direction = (PointerPos - (Vector2)transform.position).normalized;
        transform.right = direction;

        //Flip weapon
        Vector2 scale = transform.localScale;

        if(direction.x < 0)
        {
            scale.y = -1;
        }
        else 
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        //Sorting layer default = 10
        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponSR.sortingOrder = characterSR.sortingOrder - 1;
        }
        else
        {
            weaponSR.sortingOrder = characterSR.sortingOrder + 1;
        }
    }
}
