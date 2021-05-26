using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";

    [Header("Limits for player movement")]
    [SerializeField] float minX = 1.5f;
    [SerializeField] float maxX = 7.5f;
    [SerializeField] float minY = 0.66f;
    [SerializeField] float maxY = 9.28f;

    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        VerticalMovement();
    }

   

    private void HorizontalMovement()
    {
        var deltaX = Input.GetAxis(HORIZONTAL_AXIS) * Time.deltaTime * moveSpeed;
        var newXpos = Mathf.Clamp((transform.position.x + deltaX), minX, maxX);
        transform.position = new Vector2(newXpos, transform.position.y);
    }

    private void VerticalMovement()
    {
        var deltaY = Input.GetAxis(VERTICAL_AXIS) * Time.deltaTime * moveSpeed;
        var newYpos = Mathf.Clamp((transform.position.y + deltaY), minY, maxY);
        transform.position = new Vector2(transform.position.x, newYpos);
    }

   
}
