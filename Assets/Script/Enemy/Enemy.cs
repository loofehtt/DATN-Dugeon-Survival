using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Enemy : MonoBehaviour
{
    public EnemyStateMachine StateMachine { get; private set; }

    public EnemyIdleState IdleState { get; private set; }

    public EnemyMoveState MoveState { get; private set; }

    public EnemyAttackState AttackState { get; private set; }

    public Animator Anim { get; private set; }

    public EnemySO enemyData { get; private set; }

    public Rigidbody2D RB { get; private set; }

    public SpriteRenderer SR { get; private set; }

    //Pathfinding
    public Path M_Path { get; private set; }
    public Seeker Seeker { get; private set; }
    public Player Player { get; private set; }
    
    [HideInInspector] public int CurrentWaypoint;


    private void Awake()
    {
        enemyData = GetComponentInParent<EnemyCtrl>().enemyData;

        Player = FindAnyObjectByType<Player>();
        StateMachine = new EnemyStateMachine();
        IdleState = new EnemyIdleState(this, StateMachine, enemyData, "idle", Player);
        MoveState = new EnemyMoveState(this, StateMachine, enemyData, "move", Player);
        AttackState = new EnemyAttackState(this, StateMachine, enemyData, "attack", Player);
    }

    private void Start()
    {
        InvokeRepeating("UpdatePath", 0f, 0.5f);

        Seeker = GetComponent<Seeker>();
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

    void UpdatePath()
    {
        if (Seeker.IsDone())
        {
            Seeker.StartPath(transform.position, Player.transform.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            M_Path = p;
            CurrentWaypoint = 0;
        }
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
