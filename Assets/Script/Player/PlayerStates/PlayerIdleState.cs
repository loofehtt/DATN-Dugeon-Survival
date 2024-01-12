using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    protected Vector2 input;
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerSO playerData, PlayerDamageReceiver damageReceiver, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        if(player.DamageReceiver.Hp == 0 )
        {
            stateMachine.ChangeState(player.DeathState);
        }

        if (input != Vector2.zero)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        input = InputManager.Instance.KeyboardInput.normalized;

    }
}
