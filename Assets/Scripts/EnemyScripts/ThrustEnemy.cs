using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustEnemy : MonoBehaviour
{
    [SerializeField] private int dashesTillThrust = 3;
    [SerializeField] private int damage = 6;
    [SerializeField] private float pauseTime = 0.4f;
    [SerializeField] private float dashTime = 0.8f;
    [SerializeField] private float thrustTime = 0.6f;
    [SerializeField] private float dashSpeed = 8.0f;
    [SerializeField] private float thrustSpeed = 16.0f;
    [SerializeField] private float walkSpeed = 3.6f;
    [SerializeField] private float angleVariance = 110.0f;
    [SerializeField] private CircleCollider2D areaOfSight;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform hitbox;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 lastDir;
    private float dashTimer = 0.0f;
    private float thrustTimer = 0.0f;
    private float pauseTimer = 0.0f;
    private int dashCounter = 0;
    private bool patrolling = true;
    private bool dashing = false;
    private bool thrusting = false;
    private bool initialThrustLook = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastDir = Vector2.one;
        pauseTimer = pauseTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindPlayer();

        if (patrolling && !thrusting)
        {
            //transform.LookAt(transform.position + (Vector3)lastDir);

            if (!dashing)
            {
                if (pauseTimer > 0.0f)
                {
                    rb.velocity = lastDir * walkSpeed;
                    pauseTimer -= Time.deltaTime;

                    if (pauseTimer <= 0.0f)
                    {
                        pauseTimer = 0.0f;
                        RandomDash();
                    }
                }
            }
            else
            {
                if (dashTimer > 0.0f)
                {
                    rb.velocity = lastDir * dashSpeed;
                    dashTimer -= Time.deltaTime;

                    if (dashTimer <= 0.0f)
                    {
                        dashTimer = 0.0f;
                        dashing = false;
                        pauseTimer = pauseTime;
                    }
                }
            }
        }
        else 
        {
            if (!dashing && !thrusting)
            {
                transform.LookAt(player);

                if (pauseTimer > 0.0f)
                {
                    rb.velocity = lastDir * walkSpeed;
                    pauseTimer -= Time.deltaTime;

                    if (pauseTimer <= 0.0f)
                    {
                        pauseTimer = 0.0f;
                        TargettedDash();
                        dashCounter++;
                    }
                }
            }
            else if (!thrusting)
            {
                transform.LookAt(player);

                if (dashTimer > 0.0f)
                {
                    rb.velocity = lastDir * dashSpeed;
                    dashTimer -= Time.deltaTime;

                    if (dashTimer <= 0.0f)
                    {
                        dashTimer = 0.0f;
                        dashing = false;

                        if (dashCounter >= dashesTillThrust)
                        {
                            dashCounter = 0;
                            Thrust();
                            initialThrustLook = true;
                        }
                        else
                        {
                            pauseTimer = pauseTime;
                        }
                    }
                }
            }
            
            if(thrusting)
            {
                if (initialThrustLook) 
                {
                    transform.LookAt(player);
                    initialThrustLook = false;
                }

                if (thrustTimer > 0.0f) 
                {
                    rb.velocity = lastDir * thrustSpeed;
                    Strike();
                    thrustTimer -= Time.deltaTime;

                    if (thrustTimer <= 0.0f) 
                    {
                        thrustTimer = 0.0f;
                        thrusting = false;
                        pauseTimer = pauseTime;
                    }
                }
            }
        }
    }

    private void FindPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(areaOfSight.transform.position
                , areaOfSight.radius, playerLayer);

        if (playerCollider != null)
        {
            player = playerCollider.GetComponentInParent<Transform>();
            patrolling = false;
        }
        else 
        {
            patrolling = true;
        }
    }

    private void RandomDash() 
    {
        lastDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        dashing = true;
        dashTimer = dashTime;
    }

    private void TargettedDash() 
    {
        float angleToPlayer = Mathf.Rad2Deg * (Mathf.Atan2(player.position.y - transform.position.y
                                                                  , player.position.x - transform.position.x));
        angleToPlayer += Random.Range(-angleVariance, angleVariance);
        lastDir = new Vector2(Mathf.Cos(angleToPlayer * Mathf.Deg2Rad), Mathf.Sin(angleToPlayer * Mathf.Deg2Rad));
        dashing = true;
        dashTimer = dashTime;
    }

    private void Thrust() 
    {
        lastDir = (player.position - transform.position).normalized;
        thrusting = true;
        thrustTimer = thrustTime;
    }

    private void Strike() 
    {
        Collider2D playerCollider = Physics2D.OverlapBox(hitbox.position, hitbox.lossyScale, hitbox.rotation.z, playerLayer);

        if (playerCollider != null) 
        {
            Debug.Log("DOING " + damage + "DMG TO PLAYER");
            playerCollider.GetComponentInParent<HealthManager>().damagePlayer(damage);
        }
    }
}
