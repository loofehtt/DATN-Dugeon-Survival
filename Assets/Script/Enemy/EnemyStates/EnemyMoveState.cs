using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMoveState : EnemyIdleState
{
    protected Vector2 dir;
    public EnemyMoveState(Enemy enemy, EnemyStateMachine stateMachine, EnemySO enemyData, string animBoolName, Player player) : base(enemy, stateMachine, enemyData, animBoolName, player)
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

        if (distance > chaseRange)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }

        else if (distance <= attackRange)
        {
            //attack state
            stateMachine.ChangeState(enemy.AttackState);
        }



    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //flip sprite
        enemy.CheckShouldFlip(dir.x);

        Moving();

    }

    private void Moving()
    {

        if (enemy.M_Path == null) return;

        float distance = Vector2.Distance(enemy.transform.position, enemy.M_Path.vectorPath[enemy.CurrentWaypoint]);

        if (enemy.CurrentWaypoint >= enemy.M_Path.vectorPath.Count) return;

        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.M_Path.vectorPath[enemy.CurrentWaypoint], enemyData.moveSpeed * Time.deltaTime);

        dir = enemy.M_Path.vectorPath[enemy.CurrentWaypoint] - enemy.transform.position;


        if (distance < 0.1f)
        {
            enemy.CurrentWaypoint++;
        }

    }
}
