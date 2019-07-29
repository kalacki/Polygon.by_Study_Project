using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : BaseCharacterController
{
    void Start()
    {
        
    }

    void Update()
    {
        ProcessPlayerMovement();

        ProcessPlayerLook();
    }

    void ProcessPlayerLook()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        LookAt(mouseWorldPosition);
    }

    void ProcessPlayerMovement()
    {
        float deltaMoving = MovingSpeed * Time.deltaTime;

        Vector2 deltaPosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * deltaMoving;

        transform.position += (Vector3)deltaPosition;
    }

    public override void Die()
    {
        Destroy(gameObject);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
