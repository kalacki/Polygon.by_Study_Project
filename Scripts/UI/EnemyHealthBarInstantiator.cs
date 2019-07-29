using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject HealthBarPrefab;

    void Start()
    {
        InstantiateHB();
    }

    public void InstantiateHB()
    {
        GameObject healtBarGO = Instantiate(HealthBarPrefab, transform.position, Quaternion.identity);//instantiate new prefab instance 

        EnemyController enemy = GetComponent<EnemyController>(); //Get enemy character component from current game object

        HealthBar healthBar = healtBarGO.GetComponent<HealthBar>(); //Get HealthBar component from new instance

        healthBar.SetCharacter(enemy);//Bind healthBar with character
    }
}
