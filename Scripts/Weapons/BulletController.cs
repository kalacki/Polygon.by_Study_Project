using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float LifeTime = 1;
    [SerializeField] private float MovingSpeed = 10;
    [SerializeField] private float Damage = 10;

    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        ProcessMoving();
    }

    void ProcessMoving()
    {
        float deltaMoving = MovingSpeed * Time.deltaTime;

        transform.position += transform.right * deltaMoving;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        BaseCharacterController character = col.GetComponent<BaseCharacterController>();

        if (character != null)
        {
            Destroy(gameObject);

            character.Damage(Damage);
        }
    }

}
