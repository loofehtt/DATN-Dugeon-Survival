using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private void Update()
    {
        transform.Translate(Vector3.right * speed *Time.deltaTime);
    }
}
