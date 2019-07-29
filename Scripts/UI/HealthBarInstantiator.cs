using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject HealthBarPrefab;

    void Start()
    {
        InstantiateHB();
    }

    public void InstantiateHB()
    {
        GameObject healtBarGO = Instantiate(HealthBarPrefab, transform.position, Quaternion.identity);//instantiate new prefab instance 

        BaseCharacterController character = GetComponent<BaseCharacterController>(); //Get character component from current game object

        HealthBar healthBar = healtBarGO.GetComponent<HealthBar>(); //Get HealthBar component from new instance

        healthBar.SetCharacter(character);//Bind healthBar with character
    }
}
