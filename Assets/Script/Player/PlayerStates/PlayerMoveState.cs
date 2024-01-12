using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerIdleState
{

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerSO playerData, PlayerDamageReceiver damageReceiver, string animBoolName) : base(player, stateMachine, playerData, damageReceiver, animBoolName)
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

        if (player.DamageReceiver.Hp == 0)
        {
            stateMachine.ChangeState(player.DeathState);
        }

        player.SetVelocity(input * playerData.moveSpeed);

        player.CheckShouldFlip(input.x);

        if (input == Vector2.zero)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
