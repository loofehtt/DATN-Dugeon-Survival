using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected float distance;
    protected float chaseRange;
    protected float attackRange;
    protected Vector2 dir;

    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, EnemySO enemyData, string animBoolName, Player player) : base(enemy, stateMachine, enemyData, animBoolName, player)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        if (distance < chaseRange && distance > attackRange)
        {
            stateMachine.ChangeState(enemy.MoveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        distance = Vector2.Distance(enemy.transform.position, player.transform.position);

        chaseRange = enemyData.chaseRange;
        attackRange = enemyData.attackRange;
    }
}
