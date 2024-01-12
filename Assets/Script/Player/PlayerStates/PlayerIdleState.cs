using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerIdleState : PlayerState
{
    protected Vector2 input;
    protected Vector3 mouseWorld;
    protected Vector3 mouseToChar;
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

        if (player.DamageReceiver.Hp == 0)
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

        //Check should flip
        mouseWorld = InputManager.Instance.MousePos;

        mouseToChar = mouseWorld - player.transform.position;

        player.ShouldFlip(mouseToChar);
    }
}
