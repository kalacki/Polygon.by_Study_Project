using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseCharacterController
{
    [SerializeField] private float DistanceToMeleeAttack = 0.1f;
    [SerializeField] private float MeleeAttackTimeout = 0.5f;
    [SerializeField] private float MeleeAttackDamage = 20f;

    private PlayerController player;

    private float _lastAttackTime = 0;

    protected override void Awake()
    {
        base.Awake();

        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        LookAt(player.transform.position);

        float distance = (transform.position - player.transform.position).magnitude;

        if (distance <= DistanceToMeleeAttack)
        {
            if (Time.time - _lastAttackTime > MeleeAttackTimeout)
            {
                AttackPlayer();
            }
        }
        else
        {
            MoveToPlayer();
        }
    }

    void AttackPlayer()
    {
        player.Damage(MeleeAttackDamage);

        _lastAttackTime = Time.time;
    }

    void MoveToPlayer()
    {
        float deltaMoving = MovingSpeed * Time.deltaTime;

        transform.position += transform.right * deltaMoving;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
