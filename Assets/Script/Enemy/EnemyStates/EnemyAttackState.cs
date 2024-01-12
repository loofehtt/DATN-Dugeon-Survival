using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackState : EnemyIdleState
{
    private float attackTimer = 2f;
    protected Vector2 dir;

    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine, EnemySO enemyData, string animBoolName, Player player) : base(enemy, stateMachine, enemyData, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (distance > attackRange)
        {
            stateMachine.ChangeState(enemy.MoveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!enemyData.isMelee)
        {
            Shooting();

        }

        //flip sprite
        dir = player.transform.position - enemy.transform.position;
        enemy.CheckShouldFlip(dir.x);

    }

    void Shooting()
    {
        attackTimer += Time.fixedDeltaTime;

        if (attackTimer < enemyData.attackDelay) return;
        attackTimer = 0;

        Vector3 spawnPos = enemy.transform.position;
        Quaternion rotation = enemy.transform.rotation;
        Transform newBullet = BulletPool.Instance.Spawn("Enemy_Bullet", spawnPos, rotation);
        newBullet.GetComponent<EnemyBulletFly>().dir = (player.transform.position - newBullet.transform.position).normalized;
    }

}
