using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacterController : MonoBehaviour
{
    public float MovingSpeed = 1f;
    public float Health = 100f;

    public delegate void CharacterDamagedDelegate(float healthPercent);

    public event CharacterDamagedDelegate OnDamaged;
    public event Action OnDied;

    private float _startHealth;

     protected virtual void Awake()
    {
        _startHealth = Health;
    }

    protected void LookAt(Vector3 lookPosition)
    {
        Vector3 deltaPos = lookPosition - transform.position;

        float angle = Mathf.Atan2(deltaPos.y, deltaPos.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public virtual void Damage(float amount)
    {
        if (Health <= 0)
        {
            return;
        }

        Health -= amount;

        if (OnDamaged != null)
        {
            OnDamaged(Mathf.Clamp01(Health / _startHealth));
        }

        if (Health <= 0)
        {
            Die();

            if (OnDied != null)
            {
                OnDied();
            }
        }
    }

    public abstract void Die();
}
