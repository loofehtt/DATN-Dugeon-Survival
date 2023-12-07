using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected EnemySO enemyData;

    private string animBoolName;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, EnemySO enemyData, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.enemyData = enemyData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        enemy.Anim.SetBool(animBoolName, true);

        Debug.Log("Enemy: " + animBoolName);
    }

    public virtual void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
