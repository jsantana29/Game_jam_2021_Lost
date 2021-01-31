using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotTurret : MonoBehaviour
{
    [SerializeField] private List<Transform> firePoints;
    [SerializeField] private List<GameObject> projectiles;
    [SerializeField] private float attackRate = 0.3f;
    [SerializeField] private CircleCollider2D areaOfSight;
    [SerializeField] private LayerMask playerLayer;
    private float reloadTimer = 0.0f;
    private bool attacking = false;

    // Update is called once per frame
    void Update()
    {
        if (!attacking)
        {
            FindPlayer();
        }
        else
        {
            reloadTimer -= Time.deltaTime;

            if (reloadTimer <= 0.0f)
            {
                FireShot();
            }
        }
    }

    private void FireShot()
    {
        if (projectiles.Count > 0)
        {
            int projectileIndex = 0;

            foreach (Transform firePoint in firePoints) 
            {
                float projectileRotation = Mathf.Rad2Deg * (Mathf.Atan2(firePoint.position.y - transform.position.y
                                                                  , firePoint.position.x - transform.position.x));

                EnemyProjectile newProjectile = Instantiate(projectiles[projectileIndex], firePoint.position
                                                , Quaternion.Euler(0.0f, 0.0f, projectileRotation)).GetComponent<EnemyProjectile>();
                newProjectile.SetDirection((firePoint.position - transform.position).normalized);
                projectileIndex++;
            }

            reloadTimer = attackRate;
        }
    }

    private void FindPlayer()
    {
        if (Physics2D.OverlapCircle(areaOfSight.transform.position, areaOfSight.radius, playerLayer))
        {
            attacking = true;
        }
    }
}
