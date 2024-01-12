using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected bool isDead = false;
    protected HealthDisplay healthDisplay;
    public double Hp => hp;
    public double MaxHp => maxHp;

    protected virtual void Awake()
    {
        LoadComponents();
        Reborn();
    }

    protected virtual void OnEnable()
    {
        Reborn();
    }

    public virtual void Reborn()
    {
        hp = maxHp;
        healthDisplay.UpdateHealthBar(hp, maxHp);
        isDead = false;
        //Debug.Log("hp: " + hp);
    }

    public virtual void Heal()
    {
        hp = maxHp;
        healthDisplay.UpdateHealthBar(hp, maxHp);
        isDead = false;
        Debug.Log("Healed");
    }

    public virtual void Add(int add)
    {
        if (isDead) return;

        hp += add;
        healthDisplay.UpdateHealthBar(hp, maxHp);
        if (hp > maxHp) hp = maxHp;
    }

    public virtual void Deduct(int deduct)
    {
        if (isDead) return;

        hp -= deduct;
        healthDisplay.UpdateHealthBar(hp, maxHp);
        if (hp < 0) hp = 0;
        CheckIsDead();
        Debug.Log(deduct);
    }

    public virtual bool IsDead()
    {
        return hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        isDead = true;
        OnDead();
    }

    protected abstract void LoadComponents();

    protected abstract void OnDead();
}
