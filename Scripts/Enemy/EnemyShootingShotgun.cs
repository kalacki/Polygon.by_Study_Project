using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingShotgun : MonoBehaviour
{
    [SerializeField] private Transform ShootingPoint;
    [SerializeField] private Transform ShootingPoint1;
    [SerializeField] private Transform ShootingPoint2;

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
        Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint1.rotation);
        Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint2.rotation);
    }

    //transform.eulerAngles = new Vector3(0, 0, angle);
}
