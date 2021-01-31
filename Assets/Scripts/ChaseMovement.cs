using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMovement : MonoBehaviour
{
    [SerializeField] private CircleCollider2D areaOfSight;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float speed = 4.0f;
    private Rigidbody2D rb;
    private Transform player;
    private bool chasing = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        FindPlayer();

        if (chasing)
        {
            if (player != null)
            {
                rb.velocity = (player.position - transform.position).normalized * speed;    
            }
        }
        else 
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void FindPlayer()
    {
        player = Physics2D.OverlapCircle(areaOfSight.transform.position
                , areaOfSight.radius, playerLayer).GetComponentInParent<Transform>();

        chasing = player != null;
    }

    
}
