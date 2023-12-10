using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyMoveState : EnemyIdleState
{
    public EnemyMoveState(Enemy enemy, EnemyStateMachine stateMachine, EnemySO enemyData, string animBoolName, Player player) : base(enemy, stateMachine, enemyData, animBoolName, player)
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

        if (distance > chaseRange)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }

        if (distance <= attackRange)
        {
            //attack state
            stateMachine.ChangeState(enemy.IdleState);
        }

        //flip sprite

        enemy.CheckShouldFlip(dir.x);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Moving();
    }

    private void Moving()
    {

        if (enemy.M_Path == null) return;

        float distance = Vector2.Distance(enemy.transform.position, enemy.M_Path.vectorPath[enemy.CurrentWaypoint]);

        if (enemy.CurrentWaypoint >= enemy.M_Path.vectorPath.Count) return;

        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.M_Path.vectorPath[enemy.CurrentWaypoint], enemyData.moveSpeed * Time.deltaTime);



        if (distance < 0.1f)
        {
            enemy.CurrentWaypoint++;
        }
    }
}
