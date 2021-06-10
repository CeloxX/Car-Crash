using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] VirtualJoystickHandler jsMovement;

    [Header("Limits for player movement")]
    [SerializeField] float minX = 1.5f;
    [SerializeField] float maxX = 7.5f;
    [SerializeField] float minY = 0.66f;
    [SerializeField] float maxY = 9.28f;

    private Vector3 direction;
    
    void FixedUpdate()
    {
        direction = jsMovement.InputDirection;

        if(direction.magnitude != 0)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxX), 0f);
        }
        
    }
    
}
