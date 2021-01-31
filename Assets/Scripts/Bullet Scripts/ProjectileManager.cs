using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public int damage;
    public bool enemyProjectile;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player" && enemyProjectile)
        {
            collision.gameObject.GetComponent<HealthManager>().damagePlayer(damage);
            Destroy(gameObject);
        }
        
    }
}
