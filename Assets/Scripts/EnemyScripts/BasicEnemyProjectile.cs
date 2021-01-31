using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyProjectile : EnemyProjectile
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = initialDir * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player")) 
        {
            Debug.Log("Going to do " + contactDmg + " dmg.");
            other.GetComponentInParent<HealthManager>().damagePlayer(contactDmg);
        }

        DestroySelf();
    }
}
