using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine StateMachine { get; private set; }

    public EnemyIdleState IdleState { get; private set; }

    public EnemyMoveState MoveState { get; private set; }

    public Animator Anim { get; private set; }

    [SerializeField]
    private EnemySO enemyData;

    public Rigidbody2D RB { get; private set; }

    public SpriteRenderer SR { get; private set; }

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        IdleState = new EnemyIdleState(this, StateMachine, enemyData, "idle");
        MoveState = new EnemyMoveState(this, StateMachine, enemyData, "move");
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
}
