using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }

    public PlayerMoveState MoveState { get; private set; }

    public Animator Anim { get; private set; }

    public PlayerSO playerData { get; private set; }

    public Rigidbody2D RB { get; private set; }

    public SpriteRenderer SR { get; private set; }

    private Vector2 workspace;

    private void Awake()
    {
        playerData = GetComponentInParent<PlayerCtrl>().playerData;

        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
    }

    private void Start()
    {

        Anim = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocity(Vector2 velocity)
    {
        workspace.Set(velocity.x, velocity.y);
        RB.velocity = workspace;
    }

    public void CheckShouldFlip(float xInput)
    {
        if (xInput < 0)
        {
            SR.flipX = true;
        }
        if (xInput > 0)
        {
            SR.flipX = false;
        }
    }

}
