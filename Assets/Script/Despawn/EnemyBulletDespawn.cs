using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDespawn : Despawn
{
    private DamageSender damageSender;
    [SerializeField] private Transform explodeFx;
    private void Awake()
    {
        damageSender = GetComponent<DamageSender>();
    }

    protected override void DespawnObj()
    {
        BulletPool.Instance.Despawn(transform);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            damageSender.Send(collision.transform);
            BulletPool.Instance.Despawn(transform);
            FxPool.Instance.Spawn(explodeFx.name, transform.position, transform.rotation);

        }

    }
}
