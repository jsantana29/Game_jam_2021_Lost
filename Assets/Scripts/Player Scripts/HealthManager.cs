using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    private const int MAX_HEALTH = 3;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public void damagePlayer(int damage)
    {
        currentHealth -= damage;
    }

    public void resetHealth()
    {
        currentHealth = MAX_HEALTH;
    }
}
