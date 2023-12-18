using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackState : EnemyIdleState
{
    private bool canShoot = true;

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

    IEnumerator Shooting()
    {

        if (!canShoot) yield break;

        Vector3 spawnPos = enemy.transform.position;
        Quaternion rotation = enemy.transform.rotation;
        //Transform newBullet = Instantiate(weaponData.bulletPrefab, spawnPos, rotation);
        Transform newBullet = BulletPool.Instance.Spawn("Enemy_Bullet",spawnPos, rotation);
        Debug.Log("Shooting");

        canShoot = false;
        yield return new WaitForSeconds(enemyData.attackDelay);
        canShoot = true;
    }

}
