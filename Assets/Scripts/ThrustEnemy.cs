using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustEnemy : MonoBehaviour
{
    [SerializeField] private int dashesTillThrust;
    [SerializeField] private float dashPauseTime;
    [SerializeField] private float dashTime;
    [SerializeField] private float thrustTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float thrustSpeed;
    [SerializeField] private CircleCollider2D areaofSight;
    [SerializeField] private LayerMask playerLayer;
    private Transform player;
    private Rigidbody2D rb;
    private float dashTimer = 0.0f;
    private float thrustTimer = 0.0f;
    private float pauseTimer = 0.0f;
    private int dashCounter = 0;
    private bool patrolling = true;
    private bool dashing = false;
    private bool thrusting = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
