using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerRocket : MonoBehaviour

{
    [SerializeField] private float LifeTime = 3;
    [SerializeField] private float MovingSpeed = 2;
    [SerializeField] private float Damage = 50;
    private PlayerController player;

    void Start()
    {
        Destroy(gameObject, LifeTime);
    }
    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        ProcesSearchingForPlayer();
    }

    void ProcesSearchingForPlayer()
    {
        LookAt(player.transform.position);

        float deltaMoving = MovingSpeed * Time.deltaTime;

        transform.position += transform.right * deltaMoving;

    }
    protected void LookAt(Vector3 lookPosition)
    {
        Vector3 deltaPos = lookPosition - transform.position;

        float angle = Mathf.Atan2(deltaPos.y, deltaPos.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    //void MoveToPlayer()
    //{
    //    float deltaMoving = MovingSpeed * Time.deltaTime;

    //    transform.position += transform.right * deltaMoving;
    //}

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
