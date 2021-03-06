using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTurret : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float attackRate = 0.3f;
    [SerializeField] private CircleCollider2D areaOfSight;
    [SerializeField] private LayerMask playerLayer;
    private Transform player;
    private float reloadTimer = 0.0f;
    private bool attacking = false;

    // Update is called once per frame
    void Update()
    {
        FindPlayer();

        if (attacking)
        {
            if (player != null) 
            {
                transform.right = player.position - transform.position;
            }

            reloadTimer -= Time.deltaTime;

            if (reloadTimer <= 0.0f)
            {
                FireShot();
            }
        }
    }

    private void FireShot()
    {
        if (projectile != null)
        {
            EnemyProjectile newProjectile = Instantiate(projectile, firePoint.position, transform.rotation).GetComponent<EnemyProjectile>();
            newProjectile.SetDirection((firePoint.position - transform.position).normalized);
            reloadTimer = attackRate;
        }
    }

    private void FindPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(areaOfSight.transform.position
                , areaOfSight.radius, playerLayer);

        if (playerCollider != null)
        {
            player = playerCollider.GetComponentInParent<Transform>();
            attacking = true;
        }
        else
        {
            attacking = false;
        }
    }
}
