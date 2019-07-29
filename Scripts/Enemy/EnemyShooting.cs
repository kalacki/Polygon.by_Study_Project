using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform ShootingPoint;



    [SerializeField] private GameObject BulletPrefab;

    [SerializeField] private float ShootingTimeout = 2;

    

    void Start()
    {
        StartCoroutine(ShootingCoroutine());
    }

    IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShootingTimeout);

            Shoot();
        }
    }


    public void Shoot()
    {
        Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);

    }
}
