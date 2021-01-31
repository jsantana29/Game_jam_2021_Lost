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

            for(int firePointIndex = 0; firePointIndex < firePoints.Count; firePointIndex++ ) 
            {
                float projectileRotation = Mathf.Rad2Deg * (Mathf.Atan2(firePoints[firePointIndex].position.y - transform.position.y
                                                                  , firePoints[firePointIndex].position.x - transform.position.x));

                EnemyProjectile newProjectile = Instantiate(projectiles[projectileIndex], firePoints[firePointIndex].position
                                                , Quaternion.Euler(0.0f, 0.0f, projectileRotation)).GetComponent<EnemyProjectile>();
                newProjectile.SetDirection((firePoints[firePointIndex].position - transform.position).normalized);
                projectileIndex++;

                if (projectileIndex >= projectiles.Count) 
                {
                    projectileIndex = 0;
                }
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
