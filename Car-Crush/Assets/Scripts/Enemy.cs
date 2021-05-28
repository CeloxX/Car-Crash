using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameSession.Instance.SubtractLife();
        Destroy(gameObject);
    }
}
