using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackState : EnemyIdleState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine, EnemySO enemyData, string animBoolName, Player player) : base(enemy, stateMachine, enemyData, animBoolName, player)
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

        if (distance > attackRange)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }

        //flip sprite

        enemy.CheckShouldFlip(dir.x);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

}
