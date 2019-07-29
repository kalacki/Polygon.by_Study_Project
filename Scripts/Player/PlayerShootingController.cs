using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private Transform ShootingPoint;

    [SerializeField] private GameObject BulletPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
    }

    
}
